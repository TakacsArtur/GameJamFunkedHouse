using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionsEnum
{
    public enum MissonNames{
        SomethingOld,
        SuchA90sKid
    }

    public List<string> CluesList(MissonNames missonNames){
        switch(missonNames){
            case MissonNames.SomethingOld:
                return new List<string> {"Something old" , "Seomething new", "Something borrowed", "Something blue"};
            case MissonNames.SuchA90sKid:
                return new List<string>{"Things that existed in the nineties, but not before"};
            default:
                return new List<string> {"Something old" , "Seomething new", "Something borrowed", "Something blue"};
        }
    }
}
