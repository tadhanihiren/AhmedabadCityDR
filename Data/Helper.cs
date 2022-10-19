namespace AhmedabadCityDR.Data
{
    public static class Helper
    {
        #region Public Methods

        /// <summary>
        /// Convert date from string if its valid.
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>Returns string date if valid or Null</returns>
        public static string ConvertDate(string? date)
        {
            if (string.IsNullOrEmpty(date) == false)
            {
                var newDate = string.Empty;

                if (DateTime.TryParse(date, out var dateOnly) == true)
                {
                    newDate = $"{dateOnly.Day}-{dateOnly.Month}-{dateOnly.Year}";
                }

                return newDate;
            }

            return string.Empty;
        }

        #endregion

    }
}
