using System.Linq;
public class Word{
    private string _word;
    private bool _hidden = false;
    public Word(string word){
        _word = word;
    }

    public string getWord(bool hidden){
        //returns the _word string if hidden if false, otherwise, return "-" for each caractor in the _word
        string newWord = "";

        if(_hidden && hidden){
            foreach(char x in _word){
                newWord += "-";
            }
        }
        else{
            newWord = _word;
        }
        return newWord;
    }

    public void hidWord(){
        //sets _hidden to true
        _hidden = true;
    }

    public bool isHidden(){
        //returns if the word is hidden
        return _hidden;
    }

}