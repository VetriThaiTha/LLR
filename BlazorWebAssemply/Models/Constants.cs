using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Models
{
    public class LinkDefinition
    {
        public LinkDefinition(string link, string name, string desc)
        {
            Link = link;
            Name = name;
            Desc = desc;

        }
        public string Link { get; private set; }
        public string Name { get; private set; }
        public string Desc { get; private set; }
    }

    public class Constants
    {
        public static string Url_Document_Principle = "https://medium.com/@thaithavetri/land-registration-reform-principle-b267413b7365?source=friends_link&sk=4bb8f01b0f9714e30ec1b230284cd67d";
        public static string Url_Document_Plan = "https://medium.com/@thaithavetri/plan-details-cfc7f89c01a4?source=friends_link&sk=49bc148c6ca8802ef12778de16aa295a";
        public static string Url_Document_Scenario = "https://medium.com/@thaithavetri/scenarios-land-registration-reform-c6c0e0b8047a?source=friends_link&sk=37192b61d9d271d1219e5946c3720d71";
        public static string Url_Document_References = "https://medium.com/@thaithavetri/references-36670c187a0a";


        public static string Url_Video_Main = "https://www.youtube.com/watch?v=wXPBNq0mb7I&list=PL0p_U_-Or0_P31P751VvT81OwYEDX0KyC&index=2";
        public static string Url_Video_Faq = "https://www.youtube.com/watch?v=TBtxBxYsUvU&list=PL0p_U_-Or0_P31P751VvT81OwYEDX0KyC&index=3";
        public static string Url_Video_Details = "https://www.youtube.com/watch?v=-SiythpXx1U&list=PL0p_U_-Or0_P31P751VvT81OwYEDX0KyC&index=4";
        public static Dictionary<int,LinkDefinition> LinkDefinitions = new Dictionary<int, LinkDefinition>();

        static Constants()
        {
            LinkDefinitions.Add(100, new LinkDefinition(Url_Video_Main,
                                         "Main video", "A video which explains the principle of the land registration reform."
                                        ));
            LinkDefinitions.Add(200, new LinkDefinition(Url_Video_Faq,
                                         "Faq video", "Explains the impacts."
                ));
            LinkDefinitions.Add(300, new LinkDefinition(Url_Video_Details,
                                         "Technical details", "Explains the technical details."
                ));
        }


    }
}
