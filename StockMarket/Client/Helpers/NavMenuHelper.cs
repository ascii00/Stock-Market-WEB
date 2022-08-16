using System;
using System.Threading.Tasks;

namespace StockMarket.Client.Helpers
{
    public class NavMenuHelper
    {
        public static string SectionHome = "nav__link active";
        public static string SectionProfile = "nav__link";
        public static string SectionNews = "nav__link";
        public static string SectionExplore = "nav__link";
        public static string SectionSaved = "nav__link";

        public static void ChangeActiveSection(string section)
        {
            ResetSections();
            switch (section)
            {
                case "Home":
                    SectionHome = "nav__link active";
                    break;
                case "Profile":
                    SectionProfile = "nav__link active";
                    break;
                case "News":
                    SectionNews = "nav__link active";
                    break;
                case "Explore":
                    SectionExplore = "nav__link active";
                    break;
                case "Saved":
                    SectionSaved = "nav__link active";
                    break;
            }
        }
    private static void ResetSections()
        {
            SectionHome = "nav__link";
            SectionProfile = "nav__link";
            SectionNews = "nav__link";
            SectionExplore = "nav__link";
            SectionSaved = "nav__link";
        }
    }
}