namespace TutorHubAPI.Functions
{
    public class Overlapping
    {
        public bool CheckForNonOverlappingIntervals(List<string> intervals)
        {
            List<(int start, int end)> parsedIntervals = new List<(int, int)>();

            // Parse each interval and convert it to a tuple of integers
            foreach (var interval in intervals)
            {
                var parts = interval.Split('-');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int start) &&
                    int.TryParse(parts[1], out int end))
                {
                    // Add the parsed interval (start, end)
                    parsedIntervals.Add((start, end));
                }
            }

            // Check for overlaps
            for (int i = 0; i < parsedIntervals.Count; i++)
            {
                for (int j = i + 1; j < parsedIntervals.Count; j++)
                {
                    if (IsOverlapping(parsedIntervals[i], parsedIntervals[j]))
                    {
                        return false; // Found overlapping intervals
                    }
                }
            }

            return true; // No overlapping intervals
        }

        // Check if two intervals overlap
        private static bool IsOverlapping((int start, int end) interval1, (int start, int end) interval2)
        {
            return interval1.start < interval2.end && interval2.start < interval1.end;
        }
    }
}
