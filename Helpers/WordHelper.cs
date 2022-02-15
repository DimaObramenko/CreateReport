using MaterialTestTracker.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace MaterialTestTracker
{
    class WordHelper
    {
        #region Fields

        private string TemplateFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Temp.docx");
        
        #endregion

        #region Constructors

        public WordHelper() { }

        #endregion

        #region Methods

        public void Formation(Dictionary<string, string> dictionary)
        {
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                var wordDocument = wordApp.Documents.Open(TemplateFileName);

                string newFileName = "";
                foreach (var pair in dictionary)
                {
                    if (pair.Key == "date")
                    {
                        string[] s = (pair.Value).Split(new char[] { '.' });
                        string day = Convert.ToInt32(s[0]).ToString();
                        string month = s[1].ToString();
                        string year = s[2].ToString().Substring(0, 4);
                        switch (s[1].ToString())
                        {
                            case "01":
                                month = "січня"; break;
                            case "02":
                                month = "лютого"; break;
                            case "03":
                                month = "березня"; break;
                            case "04":
                                month = "квітня"; break;
                            case "05":
                                month = "травня"; break;
                            case "06":
                                month = "червня"; break;
                            case "07":
                                month = "липня"; break;
                            case "08":
                                month = "серпня"; break;
                            case "09":
                                month = "вересня"; break;
                            case "10":
                                month = "жовтня"; break;
                            case "11":
                                month = "листопада"; break;
                            default:
                                month = "грудня"; break;
                        }
                        string date = day + " " + month + " " + year;
                        
                        ReplaceWord("{" + pair.Key + "}", date, wordDocument);
                        ReplaceWord("{" + pair.Key + "}", date, wordDocument);
                    }
                    else ReplaceWord("{" + pair.Key + "}", pair.Value, wordDocument);
                    if (pair.Key == "protocol" || pair.Key == "material") newFileName += pair.Value;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Документ Microsoft Word|*.docx";
                if (sfd.ShowDialog() == true)
                {
                    sfd.Filter = "Text file (*.txt)|*.txt";
                    string path = sfd.FileName;
                    wordDocument.SaveAs2(path);
                }
                wordDocument.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wordApp.Quit();
            }
        }

        public void ReplaceWord(string stub, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stub, ReplaceWith: text);
        }

        #endregion
    }
}
