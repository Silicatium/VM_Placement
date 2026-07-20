using OptimizationDiplom.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OptimizationDiplom.JsonStorage
{
    /*
     * Класс работы с JSON-файлами
     */
    static internal class Storage
    {
        private static readonly JsonSerializerOptions Opt = new() { WriteIndented = true };

        // Настройки
        public static void SaveConfig(string path, GAConfiguration cfg) =>
            File.WriteAllText(path, JsonSerializer.Serialize(cfg, Opt));

        public static GAConfiguration LoadConfig(string path)
        {
            if (File.Exists(path))
            {
                var result = JsonSerializer.Deserialize<GAConfiguration>(File.ReadAllText(path), Opt);
                return result ?? new GAConfiguration();
            }
            var defaultCfg = new GAConfiguration();
            SaveConfig(path, defaultCfg);
            return defaultCfg;
        }

        // Серверы
        public static void SaveServers(string path, List<Server> servers) =>
            File.WriteAllText(path, JsonSerializer.Serialize(servers, Opt));

        public static List<Server> LoadServers(string path)
        {
            if (File.Exists(path))
            {
                var result = JsonSerializer.Deserialize<List<Server>>(File.ReadAllText(path), Opt);
                return result ?? new List<Server>();
            }
            var defaultServers = new List<Server>();
            SaveServers(path, defaultServers);
            return defaultServers;
        }

        // Виртуальные машины
        public static void SaveVMs(string path, List<VirtualMachine> vms) =>
            File.WriteAllText(path, JsonSerializer.Serialize(vms, Opt));

        public static List<VirtualMachine> LoadVMs(string path)
        {
            if (File.Exists(path))
            {
                var result = JsonSerializer.Deserialize<List<VirtualMachine>>(File.ReadAllText(path), Opt);
                return result ?? new List<VirtualMachine>();
            }
            var defaultVms = new List<VirtualMachine>();
            SaveVMs(path, defaultVms);
            return defaultVms;
        }

        // Упаковка
        public static void SavePlacement(string path, int[] placement) =>
            File.WriteAllText(path, JsonSerializer.Serialize(placement, Opt));

        public static int[] LoadPlacement(string path)
        {
            if (File.Exists(path))
            {
                var result = JsonSerializer.Deserialize<int[]>(File.ReadAllText(path), Opt);
                return result ?? new int[0];
            }
            var defaultPlacement = new int[0];
            SavePlacement(path, defaultPlacement);
            return defaultPlacement;
        }
    }
}
