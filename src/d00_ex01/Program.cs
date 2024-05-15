
int LevenshteinDistance(string s, string t) {
    int[,] A = new int[s.Length + 1, t.Length + 1];
    int rows = A.GetUpperBound(0) + 1;
    int cols = A.Length / rows;

    for (int i = 0; i < cols; i++) {
        A[0, i] = i;
    }

    for (int j = 0; j < rows; j++) {
        A[j, 0] = j;
    }

    int substitutionCost = 0;
    for (int j = 1; j < cols; j++) {
        for (int i = 1; i < rows; i++) {
            if (s[i-1] == t[j-1]) {
                substitutionCost = 0;
            } else {
                substitutionCost = 1;
            }
            int min = 0;
            int deletion = A[i-1, j] + 1;
            int insertion = A[i, j-1] + 1;
            int substitution = A[i-1, j-1] + substitutionCost;

            min = deletion;
            if (insertion < min) {
                min = insertion;
            }
            if (substitution < min) {
                min = substitution;
            }

            A[i, j] = min;
        }
    }

    // for (int i = 0; i < rows; i++) {
    //     for (int j = 0; j < cols; j++) {
    //         Console.Write($"{A[i,j]} ");
    //     }
    //     Console.WriteLine();
    // }

    return A[rows-1, cols-1];
}


async void PrintOutput() {
    string name = args[0];
    string filename = "../../materials/us_names.txt";
    bool end = false;
    using (StreamReader reader = new StreamReader(filename)) {
        string? line;
        while ((line = reader.ReadLine()) != null) {
            if (line == name) {
                Console.WriteLine($"Hello, {name}");
                end = true;
            }
        }
    }
    if (!end) {
        using (StreamReader reader = new StreamReader(filename)) {
            string? line;
                while (((line = reader.ReadLine()) != null) ) {
                    if ((LevenshteinDistance(name, line) == 1)) {
                        Console.WriteLine($"Did you mean \"{line}\"? Y/N");
                    }
                }
        }
    }
}

PrintOutput();