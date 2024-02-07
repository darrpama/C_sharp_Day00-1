if (args.Length != 3) {
    throw new ArgumentException("Number of input parameters should be = 3");
}

for (int i = 0; i < args.Length; i++) {
    Console.Write("{0} ", args[i]);
}
