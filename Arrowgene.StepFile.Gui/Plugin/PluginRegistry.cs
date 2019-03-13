using Arrowgene.StepFile.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Arrowgene.StepFile.Gui.Plugin
{
    public class PluginRegistry
    {
        private static PluginRegistry _pluginRegistry = new PluginRegistry();
        public static PluginRegistry Instance => _pluginRegistry;


        private Dictionary<Type, ICollection<IPlugin>> _plugins;

        public PluginRegistry()
        {
            _plugins = new Dictionary<Type, ICollection<IPlugin>>();
        }

        public void Load(string directory)
        {
            _plugins.Clear();
            DirectoryInfo directoryInfo = App.CreateDirectoryInfo(directory);
            if (directoryInfo == null || !directoryInfo.Exists)
            {
                return;
            }
            ICollection<Assembly> assemblies = new List<Assembly>();
            assemblies.Add(Assembly.GetExecutingAssembly());
            foreach (FileInfo dllFile in directoryInfo.GetFiles("Arrowgene.StepFile.Plugin.*.dll", SearchOption.TopDirectoryOnly))
            {
                AssemblyName an = AssemblyName.GetAssemblyName(dllFile.FullName);
                Assembly assembly = Assembly.Load(an);
                if (assembly != null)
                {
                    assemblies.Add(assembly);
                }
            }
            AddPlugins<IEz2OnArchiveCryptoPlugin>(assemblies);
            AddPlugins<ICryptoPlugin>(assemblies);
            AddPlugins<IPlugin>(assemblies);
        }

        public ICollection<T> GetPlugins<T>() where T : IPlugin
        {
            ICollection<T> plugins = new List<T>();
            Type key = typeof(T);
            if (_plugins.ContainsKey(key))
            {
                foreach (IPlugin plugin in _plugins[key])
                {
                    plugins.Add((T)plugin);
                }
            }
            return plugins;
        }

        private void AddPlugins<T>(ICollection<Assembly> assemblies) where T : IPlugin
        {
            ICollection<T> plugins = new PluginLoader<T>().Load(assemblies);
            Type key = typeof(T);
            if (!_plugins.ContainsKey(key))
            {
                _plugins.Add(key, new List<IPlugin>());
            }
            foreach (IPlugin plugin in plugins)
            {
                _plugins[key].Add(plugin);
            }
        }


    }
}
