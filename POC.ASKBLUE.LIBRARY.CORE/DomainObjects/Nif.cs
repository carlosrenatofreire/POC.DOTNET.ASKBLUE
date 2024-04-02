using POC.ASKBLUE.LIBRARY.CORE.Tools;

namespace POC.ASKBLUE.LIBRARY.CORE.DomainObjects
{
    public class Nif
    {

        public const int NifMaxLength = 9;
        public string Number { get; private set; }

        //Construtor do EntityFramework
        protected Nif() { }

        public Nif(string number)
        {
            if (!IsValid(number)) throw new DomainException("Invalid Nif");
            Number = number;
        }

        public static bool IsValid(string nif)
        {
            bool functionReturnValue = false;
            functionReturnValue = false;
            string[] s = new string[9];
            string Ss = null;
            string C = null;
            int i = 0;
            long checkDigit = 0;

            nif = nif.IsOnlyNumber(nif);

            s[0] = Convert.ToString(nif[0]);
            s[1] = Convert.ToString(nif[1]);
            s[2] = Convert.ToString(nif[2]);
            s[3] = Convert.ToString(nif[3]);
            s[4] = Convert.ToString(nif[4]);
            s[5] = Convert.ToString(nif[5]);
            s[6] = Convert.ToString(nif[6]);
            s[7] = Convert.ToString(nif[7]);
            s[8] = Convert.ToString(nif[8]);

            if (nif.Length == 9)
            {
                C = s[0];
                if (s[0] == "1" || s[0] == "2" || s[0] == "5" || s[0] == "6" || s[0] == "9")
                {
                    checkDigit = Convert.ToInt32(C) * 9;
                    for (i = 2; i <= 8; i++)
                    {
                        checkDigit = checkDigit + (Convert.ToInt32(s[i - 1]) * (10 - i));
                    }
                    checkDigit = 11 - (checkDigit % 11);
                    if ((checkDigit >= 10))
                        checkDigit = 0;
                    Ss = s[0] + s[1] + s[2] + s[3] + s[4] + s[5] + s[6] + s[7] + s[8];
                    if ((checkDigit == Convert.ToInt32(s[8])))
                        functionReturnValue = true;
                }
            }
            return functionReturnValue;
        }
    }
}
