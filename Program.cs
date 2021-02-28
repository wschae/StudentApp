using System;
using Neo.Lux.Core;
using Neo.Lux.Cryptography;
using Neo.Lux.Utils;

namespace StudentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup node
            var rpcNode = new LocalRPCNode(49332, "http://127.0.0.1:49332");

            // Setup key
            var privateKey = "{put-your-private-key-here}";
            var key = new KeyPair(privateKey.HexToBytes());
            
            // Get balances
            var balances = rpcNode.GetAssetBalancesOf(key.address);
            foreach (var entry in balances)
            {
                Console.WriteLine(entry.Value + " " + entry.Key);
            }

            // Query 'Tom Holland'
            var scriptHash = new UInt160(NeoAPI.GetScriptHashFromString("0x9948548f6e742c27d61c67a34b0ba2601b6f882b"));
            var response = rpcNode.InvokeScript(scriptHash, "query", new object[] { "Tom Holland" });
            Console.WriteLine(response.result.GetString());
        }
    }
}


