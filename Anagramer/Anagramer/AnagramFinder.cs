using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Anagramer
{
    class AnagramFinder
    {
        private List<string> wordDictionary;
        private Dictionary<string, AnagramWords> anagramsMap;
        public AnagramFinder()
        {
            anagramsMap = new Dictionary<string, AnagramWords>();
            string filePath = "C:\\Users\\isidroh\\Documents\\visual studio 2013\\Projects\\Anagramer\\google-10000-english-usa.txt";
            //string filePath = "C:\\Users\\isidroh\\Documents\\visual studio 2013\\Projects\\Anagramer\\EnglishDictionary.txt";
            LoadDictionary(filePath);
            GenerateAnagramsMap();
        }
        public List<string> ListAllAnagrams(int minWordLength, int minNumWords)
        {
            List<string> results = new List<string>();

            foreach (var anagramMapEntry in this.anagramsMap)
            {
                if(anagramMapEntry.Value.NumberOfAnagrams >= minNumWords && anagramMapEntry.Value.WordsLength >= minWordLength)
                {
                    results.Add(anagramMapEntry.Value.AllAnagramWordsInOneLine);
                }
            }
            
            return results;
        }
        public string GetSingleWordAnagramsOfWord(string word)
        {
            string signature = CalculateWordSingnature(word);
            if(this.anagramsMap.ContainsKey(signature))
            {
                return this.anagramsMap[signature].AllAnagramWordsInOneLine;
            }
            return string.Format("Word not found");
        }
        public List<string> GetMultiWordAnagramsOfWord(string word, int minLength)
        {
            var allSignatures = new List<string>();
            foreach(var anagramsMapEntry in this.anagramsMap)
            {
                if (anagramsMapEntry.Key.Length >= minLength)
                    allSignatures.Add(anagramsMapEntry.Key);
            }
            List<string> results = new List<string>();
            var multiWordAnagramList = GetMultiWordAnagramsOfWordRecursive(CalculateWordSingnature(word), allSignatures);
            foreach(var multiWordAnagram in multiWordAnagramList)
            {
                string multiWordAnagramToString = "";
                foreach(string anagramWord in multiWordAnagram)
                {
                    if (multiWordAnagramToString.Length > 0)
                        multiWordAnagramToString += " x ";
                    multiWordAnagramToString += string.Format("({0})", this.anagramsMap[anagramWord].AllAnagramWordsInOneLine);
                }
                results.Add(multiWordAnagramToString);
            }
            return results;
        }
        private List<List<string>> GetMultiWordAnagramsOfWordRecursive(string bigWordSignature, List<string> signaturesMatching)
        {
            var multiWordAnagramList = new List<List<string>>();
            if (bigWordSignature.Length == 0)
                return multiWordAnagramList;
            var listOfCandidateSignatures = GetSmallWordsContainedInWord(signaturesMatching, bigWordSignature);
            foreach(var candidateSignature in listOfCandidateSignatures)
            {
                if(candidateSignature == bigWordSignature)
                {
                    var listOfOneWord = new List<string>();
                    listOfOneWord.Add(candidateSignature);
                    multiWordAnagramList.Add(listOfOneWord);
                }
                else
                {
                    string leftOverOfBigWordSignature = GetWordAfterRemovingLetters(bigWordSignature, candidateSignature);
                    if(!WordAlreadyInList(candidateSignature, multiWordAnagramList))
                    {
                        var smallResults = GetMultiWordAnagramsOfWordRecursive(leftOverOfBigWordSignature, listOfCandidateSignatures);
                        if (smallResults.Count > 0)
                        {
                            foreach (var partialMultiWordList in smallResults)
                            {
                                partialMultiWordList.Add(candidateSignature);
                                multiWordAnagramList.Add(partialMultiWordList);
                            }
                        }
                    }
                }
            }

            return multiWordAnagramList;
        }
        private bool WordAlreadyInList(string word, List<List<string>> listOfWordLists)
        {
            foreach(var listOfWords in listOfWordLists)
            {
                foreach(string w in listOfWords)
                {
                    if (w == word)
                        return true;
                }
            }
            return false;
        }
        private List<string> GetSmallWordsContainedInWord(List<string> smallWordList, string bigWord)
        {
            var list = new List<string>();
            if (bigWord.Length == 0)
                return list;

            foreach(var smallWord in smallWordList)
            {
                if (IsLettersOfSmallWordContainedInLettersOfBigWord(smallWord, bigWord))
                    list.Add(smallWord);
            }
            return list;
        }
        private bool IsLettersOfSmallWordContainedInLettersOfBigWord(string smallWord, string bigWord)
        {
            if (bigWord.Length < smallWord.Length)
                return false;

            List<char> bigWordLetters = bigWord.ToList<char>();
            for (int i = 0; i < smallWord.Length; i++)
            {
                int index = bigWordLetters.BinarySearch(smallWord[i]);
                if (index < 0)
                    return false;
                else
                    bigWordLetters.RemoveAt(index);
            }
            return true;
        }
        private string GetWordAfterRemovingLetters(string word, string lettersToRemove)
        {
            List<char> result = word.ToList<char>();
            for (int i = 0; i < lettersToRemove.Length; i++)
            {
                int index = result.BinarySearch(lettersToRemove[i]);
                if (index < 0)
                    throw new Exception(string.Format("{0}[{1}] is not present in word {2}", lettersToRemove, i, word));
                if (index >= 0)
                    result.RemoveAt(index);
            }
            string resultAsString="";
            foreach(var c in result)
            {
                resultAsString += c;
            }
            return resultAsString;
        }

        protected void LoadDictionary(string filePath)
        {
            string line;
            this.wordDictionary = new List<string>();
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                this.wordDictionary.Add(line.ToLower());
            }

            file.Close();
        }
        protected string CalculateWordSingnature(string word)
        {
            char[] a = word.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }
        static string FormatListOfStringsInOneLine(List<string> listOfStrings, string separator)
        {
            string formattedString = "";
            foreach (var s in listOfStrings)
            {
                if (formattedString.Length > 0)
                    formattedString += separator;
                formattedString += s;
            }
            return formattedString;
        }
        protected void GenerateAnagramsMap()
        {
            foreach(string word in this.wordDictionary)
            {
                string signature = CalculateWordSingnature(word);

                if (!this.anagramsMap.ContainsKey(signature))
                {
                    var anagramWords = new AnagramWords();
                    anagramWords.AddAnagramWord(word);
                    this.anagramsMap.Add(signature, anagramWords);
                }
                else
                {
                    this.anagramsMap[signature].AddAnagramWord(word);
                }
            }
        }
        class AnagramWords
        {
            public AnagramWords()
            {
                anagramWordList = new List<string>();
                wordLength = 0;
            }
            public void AddAnagramWord(string anagramWord)
            {
                this.anagramWordList.Add(anagramWord);
                this.wordLength = anagramWord.Length;
            }
            public string AllAnagramWordsInOneLine
            {
                get
                {
                    return FormatListOfStringsInOneLine(this.anagramWordList, " - ");
                }
            }
            public int WordsLength
            {
                get
                {
                    return this.wordLength;
                }
            }
            public int NumberOfAnagrams
            {
                get
                {
                    return this.anagramWordList.Count;
                }
            }
           
            private List<string> anagramWordList;
            private int wordLength;
        }
    }
}
