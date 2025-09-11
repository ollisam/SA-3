using System.Linq;

namespace CleanThatCode.Community.Common;

// Your job is to implement this class
public static class StringHelpers
{
    // Instead of spaces it should be separated with dots, e.g. Hello World -> Hello.World
    public static string ToDotSeparatedString(this string str)
    {
        string[] words = str.Split();
        string combined_words = "";
        foreach (var word in words)
        {
            combined_words += word + "."; // adds a dot inbetween words
        }
        return combined_words.Substring(0, combined_words.Length - 1); // removes the last trailing dot
    }

    // All words in the string should be capitalized, e.g. teenage mutant ninja turtles -> Teenage Mutant Ninja Turtles
    public static string CapitalizeAllWords(this string str)
    {
        string[] words = str.Split();
        string combined_words = "";
        foreach (var word in words)
        {
            var capitalized = char.ToUpper(word[0]) + word.Substring(1); // puts the first letter to upper case and adds the rest
            combined_words += capitalized + " ";
        }
        return combined_words.Substring(0, combined_words.Length - 1); // removes the last trailing space
    }

    // The words should be reversed in the string, e.g. Hi Ho Silver Away! -> Away! Silver Ho Hi
    public static string ReverseWords(this string str)
    {
        string[] words = str.Split();
        string combined_words = "";
        foreach (var word in words.Reverse()) // iterate through in reversed orded
        {
            combined_words += word + " "; // adds space
        }
        return combined_words.Substring(0, combined_words.Length - 1); // removes the last trailing space
    }
}