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

namespace JWETestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWETestController : ControllerBase
    {
        private static byte[] aes256KWKey1 = Encoding.ASCII.GetBytes("BECEDE9F047E88314D6A9347B90E2BEC");
        private static JweRecipient recipientAes256KW1 => new JweRecipient(JweAlgorithm.A256KW, aes256KWKey1,null);
        JSSerializerMapper JSSerializerMapper = new JSSerializerMapper();
        [HttpPost]
        public JObject Encrypt_ModeCompactWithEmptyBytesA128KW_A128CBC_HS256_ExpectedResults([FromBody] CustomerDetailRequestModel Model)
        {
            var json = JSSerializerMapper.Serialize(Model);
            byte[] plaintext = Encoding.ASCII.GetBytes(json);

            var jwe = JWE.EncryptBytes(
                plaintext: plaintext,
                recipients: new JweRecipient[] { recipientAes256KW1 },
                JweEncryption.A128CBC_HS256,
                mode: SerializationMode.Json
            );
            JObject deserialized = JObject.Parse(jwe);

            return deserialized;
        }

    }
}