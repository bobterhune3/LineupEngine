using System;
using System.Collections.Generic;
using System.IO;

namespace LineupEngine { 

    public class Config
    {
        private static Config config = null;

        private const String CONFIG_FILE_NAME = "config.properties";

        Dictionary<String, String> teamMap = new Dictionary<String, String>();


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

                        teamMap.Add(key, value);
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
    }
}
