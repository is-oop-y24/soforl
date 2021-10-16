using System;
using System.Numerics;

namespace Isu.Classes
{
    public class GenerateId
    {
        public GenerateId()
        {
            Id = new BigInteger(Guid.NewGuid().ToByteArray());
        }

        public static BigInteger Id { get; private set; }
    }
}