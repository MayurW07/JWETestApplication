using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWETestApplication.Utils;
using System.Text;
using JWETestApplication.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Jose;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace JWETestApplication.Controllers
{
    [Route("api/JWETest")]
    [ApiController]
    public class JWETestController : ControllerBase
    {
        private static byte[] aes256KWKey1 = HexStringToByteArray("BECEDE9F047E88314D6A9347B90E2BECF2AF3805F5DCE0DC2DA33713884A1D9A");
        private static Utils.JweRecipient recipientAes256KW1 => new Utils.JweRecipient(Utils.JweAlgorithm.A256KW, aes256KWKey1,null);
        JSSerializerMapper JSSerializerMapper = new JSSerializerMapper();
        NewtonsoftMapper mapper = new NewtonsoftMapper();
        public static IHostingEnvironment HostingEnvironment { get; set; }

        [Route("Encrypt"),HttpPost]
        public JObject Encrypt_ModeCompactWithEmptyBytesA128KW_A128CBC_HS256_ExpectedResults([FromBody] object Model)
        {
            var json = mapper.Serialize(Model);
            byte[] plaintext = Encoding.ASCII.GetBytes(json);

            var jwe = Utils.JWE.EncryptBytes(
                plaintext: plaintext,
                recipients: new Utils.JweRecipient[] { recipientAes256KW1 },
                Utils.JweEncryption.A128CBC_HS256,
                mode: Utils.SerializationMode.Json
            );
            JObject deserialized = JObject.Parse(jwe);
          
            return deserialized;
        }

        [Route("Decrypt"),HttpPost]
        public JObject Decrypt([FromBody]object Model)
        {
            var jwe = mapper.Serialize(Model);
            Utils.JweToken jwedec = Utils.JWE.Decrypt(jwe, aes256KWKey1);           
            var response = mapper.Serialize(jwedec.Plaintext);
            dynamic json = JsonConvert.DeserializeObject(response);
            JObject deserialized = JObject.Parse(json);
            return deserialized;
        }

        public static byte[] HexStringToByteArray(string s)
        {
            int len = s.Length;
            byte[] data = new byte[len / 2];
            for (int i = 0; i < len; i += 2)
            {
                data[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
            }
            return data;
        }

    }
}