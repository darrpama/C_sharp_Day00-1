
int LevenshteinDistance(string s, string t) {
    // create two work vectors of integer distances
    int n = t.Length;
    int m = s.Length;
    int[] v0 = new int[n + 1];
    int[] v1 = new int[n + 1];

    // initialize v0 (the previous row of distances)
    // this row is A[0][i]: edit distance from an empty s to t;
    // that distance is the number of characters to append to  s to make t.
    for (int i = 0; i < n+1; i++) {
        v0[i] = i;
    }

    for (int i = 0; i < m - 1; i++) {
        // calculate v1 (current row distances) from the previous row v0

        // first element of v1 is A[i + 1][0]
        //   edit distance is delete (i + 1) chars from s to match empty t
        foreach (int v in v0) {
            Console.Write("[{0}]", v);
        }
        Console.Write("\n");


        v1[0] = i + 1;

        // use formula to fill in the rest of the row
        for (int j = 0; j < n; j++) {
            // calculating costs for A[i + 1][j + 1]
            int deletionCost = v0[j + 1] + 1;
            int insertionCost = v1[j] + 1;
            int substitutionCost = 0;
            if (s[i] == t[j]) {
                substitutionCost = v0[j];
            } else {
                substitutionCost = v0[j] + 1;
            }

            int min = deletionCost;
            if (insertionCost < min) {
                min = insertionCost;
            }
            if (deletionCost < min) {
                min = deletionCost;
            }

            v1[j + 1] = min;
        }

        // copy v1 (current row) to v0 (previous row) for next iteration
        // since data in v1 is always invalidated, a swap without copy could be more efficient
        for (int k = 0; k < n + 1; k++) {
            v0[k] = v1[k];
        }
    }
    return v0[n];
}
// after the last swap, the results of v1 are now in v0

string s1 = "sitting";
string s2 = "kitten";

Console.WriteLine(LevenshteinDistance(s1, s2));