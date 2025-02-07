﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerUtils
{
    public class Sort
    {
        public enum SortDisplayModes
        {
            COMMA,
            NEW_LINE
        }

        public enum SortStyles
        {
            ALPHABETICAL,
            REVERSED
        }

        public enum TextStyles
        {
            NORMAL,
            ALL_CAPS,
            ALL_SMALL,
        }

        public enum TextPresentations
        {
            NORMAL,
            UNDERSCORE,
        }

        readonly static string[] SPLITTERS = new string[]
        {
            ", ",
            ",",
            "\n"
        };

        readonly static Dictionary<SortDisplayModes, string> SEPERATORS = new Dictionary<SortDisplayModes, string>()
        {
            { SortDisplayModes.COMMA, ", " },
            { SortDisplayModes.NEW_LINE, "\n" }
        };

        public SortDisplayModes DisplayMode { get; private set; }
        public SortStyles SortStyle { get; private set; }
        public TextStyles TextStyle { get; private set; }
        public TextPresentations TextPresentation { get; private set; }

        public Sort(SortDisplayModes displayMode, SortStyles sortStyle, TextStyles textStyle, TextPresentations textPresentation)
        {
            DisplayMode = displayMode;
            SortStyle = sortStyle;
            TextStyle = textStyle;
            TextPresentation = textPresentation;
        }

        public string SortString(string input)
        {
            List<string> splits = input.Split(SPLITTERS, StringSplitOptions.RemoveEmptyEntries).ToList();
            splits.Sort();
            string returnString = string.Empty;
            if (SortStyle == SortStyles.REVERSED)
                splits.Reverse();
            splits.ForEach(entry =>
            {
                if (TextPresentation == TextPresentations.UNDERSCORE)
                    entry = entry.Replace(' ', '_');
                returnString += entry + SEPERATORS[DisplayMode];
            });

            if (TextStyle == TextStyles.ALL_CAPS)
                returnString = returnString.ToUpper();
            else if (TextStyle == TextStyles.ALL_SMALL)
                returnString = returnString.ToLower();

            return returnString;
        }

        public void SetDisplayMode(SortDisplayModes displayMode)
        {
            DisplayMode = displayMode;
        }

        public void SetSortStyle(SortStyles sortStyle)
        {
            SortStyle = sortStyle;
        }

        public void ChangeTextStyleToNext()
        {
            TextStyle = (TextStyles)(((int)TextStyle + 1) % Enum.GetValues(typeof(TextStyles)).Length);
        }

        public void ChangeTextPresentationToNext()
        {
            TextPresentation = (TextPresentations)(((int)TextPresentation + 1) % Enum.GetValues(typeof(TextPresentations)).Length);
        }
    }
}
