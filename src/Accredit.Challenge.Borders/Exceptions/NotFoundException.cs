using System;

namespace Accredit.Challenge.Borders.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
