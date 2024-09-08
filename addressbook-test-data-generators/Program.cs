﻿using Addressbook_web_tests;

namespace Addressbook_test_data_generators
    {
        class Program
        {
                static void Main(string[] args)
                {

                    int count = Convert.ToInt32(args[0]);
                    StreamWriter writer = new StreamWriter(args[1]);
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteLine(string.Format("${0},${1},${2}",
                        TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10)));
                    }
                    writer.Close();
                }
        }
    }

