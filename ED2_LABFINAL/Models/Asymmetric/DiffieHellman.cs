using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace ED2_LABFINAL.Models.Asymmetric
{
    public class DiffieHellman
    {
        private static BigInteger g = 43;
        private static BigInteger p = 107;
        private static BigInteger A;
        private static BigInteger B;
        private static BigInteger Alice;
        private static BigInteger Bob;
        private static BigInteger secretkey;
        public DiffieHellman(int a, int b)
        {
            A = a;
            B = b;
        }

        public void alice()
        {
            Alice = BigInteger.ModPow(g, A, p);
        }

        public void bob()
        {
            Bob = BigInteger.ModPow(g, B, p);
        }
        public void SecretKey()
        {
            //tamaño = b
            secretkey = BigInteger.ModPow(B, A, p);
        }
        public string SetSecretKey()
        {
            alice();
            bob();
            SecretKey();
            return secretkey.ToString();
        }
        public string SetAlice()
        {
            alice();
            return Alice.ToString();
        }
        public string SetBob()
        {
            bob();
            return Bob.ToString();
        }

    }
}
