using somReportUtils;
using System;
using System.Collections.Generic;
using System.IO;

namespace LineupEngine { 

    public class Config : IConfig
    {
        public static Config config = null;

        private const String CONFIG_FILE_NAME = "config.properties";

        Dictionary<String, String> teamMap = new Dictionary<String, String>();
        private static float ESTIMATE_AB_MULTIPLIER = 1f;
        private static float ESTIMATE_IP_MULTIPLIER = 1f;
        private static int AB_MINIMUM = 50;
        private static int IP_MINIMUM = 30;

        public float getABMultiplier() { return ESTIMATE_AB_MULTIPLIER; }
        public float getIPMultiplier() { return ESTIMATE_IP_MULTIPLIER; }

        public static String CSV_FILE_LOCATION = System.IO.Directory.GetCurrentDirectory();
 
        public Config()
        {
            if (File.Exists(CONFIG_FILE_NAME))
                readConfiguration(CONFIG_FILE_NAME);

        }

        public Dictionary<String,String> getTeamAbrvMapping( ) { return teamMap; }

        public void readConfiguration(String configFileName)
        {
            System.IO.StreamReader file = null;
            try
            {
                string line;

                // Read the file and display it line by line.
                file = new System.IO.StreamReader(configFileName);
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length > 0)
                    {

                        string[] values = line.Split('=');
                        string key = values[0];
                        string value = values[1];
                        float tmpFValue = 1f;
                        int tmpNValue = 1;

                        if (key.Equals("ESTIMATE_AB_MULTIPLIER"))
                        {
                            float.TryParse(value, out tmpFValue);
                            ESTIMATE_AB_MULTIPLIER = tmpFValue;
                        }
                        else if (key.Equals("ESTIMATE_IP_MULTIPLIER"))
                        {
                            float.TryParse(value, out tmpFValue);
                            ESTIMATE_IP_MULTIPLIER = tmpFValue;
                        }
                        else if (key.Equals("AB_MINIMUM"))
                        {
                            Int32.TryParse(value, out tmpNValue);
                            AB_MINIMUM = tmpNValue;
                        }
                        else if (key.Equals("IP_MINIMUM"))
                        {
                            Int32.TryParse(value, out tmpNValue);
                            IP_MINIMUM = tmpNValue;
                        }
                        else
                        {
                            teamMap.Add(key, value);
                        }
                    }
                }
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }


        public static String getConfigurationFilePath(String filename)
        {
            if (config == null)
                config = new Config();

            return Path.Combine(CSV_FILE_LOCATION, filename);
        }
        public float getMinABAllowed() { return AB_MINIMUM; }
        public float getMinIPAllowed() { return IP_MINIMUM; }
    }
}
