using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace yutokun
{
    public class ExampleSheetLoader : MonoBehaviour
    {
        public static ExampleSheetLoader Instance;

        [SerializeField]
        public TextAsset mytext; //Set is to your csv file in inspector
        public int sheetLength;//How many rows are there

        void Awake()
        {
            Instance = this;
            var sheet = CSVParser.LoadFromString(mytext.text);
            sheetLength = sheet.Count;
        }


        public string CheckTile(int row, int column)
        {
            var sheet = CSVParser.LoadFromString(mytext.text);
            string printing = "";
            if (sheet.Count > row && sheet[row].Count > column)  // Row first, then column
            {
                printing = sheet[row][column];
            }
            else
            {
                printing = "empty";
            }
            return printing;
        }
    }
}
