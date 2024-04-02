namespace POC.ASKBLUE.LIBRARY.CORE.DomainObjects
{
    public class DomainException : Exception
    {

        #region Using Constructors

        public DomainException() { }

        public DomainException(string message) : base(message) { }

        public DomainException(string message, Exception innerException) : base(message, innerException) { }

        #endregion

    }
}
