using System;

namespace DataConvertion
{
    public class StringToInt
    {
        public int? ConvertStringToInt(string input)
        {
            int? output = null;
            try
            {
                if (input == null)
                {
                    throw new NullReferenceException();
                }

                output = Convert.ToInt32(input);
            }
            catch (System.FormatException e)
            {
                throw new FormatException(e.Message);
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException(e.Message);
            }
            catch (OverflowException e)
            {
                throw new OverflowException(e.Message);
            }

            return output;
        }
    }
}