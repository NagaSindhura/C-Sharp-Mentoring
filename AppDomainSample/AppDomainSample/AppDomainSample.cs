using System;
using System.Configuration;

namespace AppDomainSample
{
    public class AppDomainSample
    {
        public static void Main()
        {
            var generateFilesPluginPath = ConfigurationManager.AppSettings["GenerateFilesPlugin"];
            var generateFilesPluginPathName = ConfigurationManager.AppSettings["GenerateFilesPluginName"];

            var appDomainSetup = new AppDomainSetup
                                     {
                                         ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            };

            var appDomainSetup1 = new AppDomainSetup
            {
                ApplicationBase = generateFilesPluginPath
            };

            var generateFilesAppDomain = AppDomain.CreateDomain(generateFilesPluginPathName);

            var thrirdPartyDomainLoader =
                (ThrirdPartyDomainLoader)
                generateFilesAppDomain.CreateInstanceAndUnwrap(
                    typeof(ThrirdPartyDomainLoader).Assembly.FullName,
                    typeof(ThrirdPartyDomainLoader).FullName);

            thrirdPartyDomainLoader.MethodInvoker(
                ApplicationBase(generateFilesPluginPath),
                generateFilesPluginPathName,
                "CreateFile",
                @"C:\",
                "temp.text");


            thrirdPartyDomainLoader.MethodInvoker(
                ApplicationBase(generateFilesPluginPath),
                generateFilesPluginPathName,
                "CreateFile",
                @"D:\",
                "temp.text");

            AppDomain.Unload(generateFilesAppDomain);

            Console.ReadLine();
        }

        public static string ApplicationBase(string path)
        {
            var appDomainSetup = new AppDomainSetup { ApplicationBase = path };

            return appDomainSetup.ApplicationBase;
        }
    }
}