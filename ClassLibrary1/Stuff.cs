using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ClassLibrary1
{
    public static class Stuff
    {
        public static byte[] GetMyStuff(string key)
        {
            byte[] retour = null;
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(key))
            {
                if (stream == null)
                {
                    throw new Exception($"Resource {key} not found in {assembly.FullName}.  Valid resources are: {String.Join(", ", assembly.GetManifestResourceNames())}.");
                }

                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    retour = ms.ToArray();
                }
            }
            return retour;
        }
    }
}
