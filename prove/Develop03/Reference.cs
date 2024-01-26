using System;
using System.Threading.Tasks.Dataflow;

public class Reference{
    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse = "";

    public Reference(string book, string chapter, string verse){
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
    }

    public Reference(string book, string chapter, string verse, string endVerse){
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = endVerse;
    }

    public string getReference(){
        if(_endVerse == ""){
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else{
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}