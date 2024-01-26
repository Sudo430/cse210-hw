public class Scripture{
    List<Word> scripture = new List<Word>();
    bool _allWordsHidden = false;

    public Scripture(string text){
        //adds each word to the list of Words
        string[] words = text.Split(" ");
        foreach(string word in words){
            scripture.Add(new Word(word));
        }
    }

    public string getScripture(bool hidden){
        //returns the scripture as a string. hides words that are hidden
        string returnStr = "";

        foreach(Word word in scripture){
            returnStr += word.getWord(hidden) + " ";
        }
        return returnStr;
    }

    public void hidWords(int amount){
        //picks randome words to hid
        Random random = new Random();

        //makes a list of the none hidden words
        List<Word> notHiddenWords = new List<Word>();
        foreach(Word word in scripture){
            if(!word.isHidden()){
                notHiddenWords.Add(word);
            }
        }

        //checks if any word are visable
        if(notHiddenWords.Count == 0){
                _allWordsHidden = true;
        }

        //hides the desired amount of words. 
        for(int i = amount; i > 0; i--){
            if(notHiddenWords.Count == 0){
                break;
            }
            int ranIndex = random.Next(0, notHiddenWords.Count);
            notHiddenWords[ranIndex].hidWord();
            notHiddenWords.RemoveAt(ranIndex);
        }
    }

    public bool allHidden(){
        //returns true if all words are hidden
        return _allWordsHidden;
    }
}