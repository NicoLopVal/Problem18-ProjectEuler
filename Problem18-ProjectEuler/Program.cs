string[] triangleLines =
                    {
                        "75" ,
                        "95 64" ,
                        "17 47 82" ,
                        "18 35 87 10" ,
                        "20 04 82 47 65" ,
                        "19 01 23 75 03 34" ,
                        "88 02 77 73 07 63 67" ,
                        "99 65 04 28 06 16 70 92" ,
                        "41 41 26 56 83 40 80 70 33" ,
                        "41 48 72 33 47 32 37 16 94 29" ,
                        "53 71 44 65 25 43 91 52 97 51 14" ,
                        "70 11 33 28 77 73 17 78 39 68 17 57" ,
                        "91 71 52 38 17 14 91 43 58 50 27 29 48" ,
                        "63 66 04 68 89 53 67 30 73 16 69 87 40 31" ,
                        "04 62 98 27 23 09 70 98 73 93 38 53 60 04 23"
                        };

int[,] triangleValues = new int[triangleLines.Length, triangleLines.Length];
int[,] triangleUtilities = new int[triangleLines.Length, triangleLines.Length];

for (int i = 0; i < triangleLines.Length; i++)       //Get the string lines into int array simulating the triangle
{
    string[] lineValues = triangleLines[i].Split(" ");
    for (int j = 0; j < lineValues.Length; j++)
    {
        triangleValues[i, j] = Convert.ToInt32(lineValues[j]);
    }
}

for (int i = triangleLines.Length - 1; i > 0; i--)       // Build the utility pyramid
{
    for (int j = 0; j <= i; j++)
    {
        if (i == triangleLines.Length - 1)
        {
            triangleUtilities[i, j] = triangleValues[i, j];
        }
        else
        {
            triangleUtilities[i, j] = triangleValues[i, j] + Math.Max(triangleUtilities[i + 1, j], triangleUtilities[i + 1, j + 1]);
        }
    }
}

int[] path = new int[triangleLines.Length];
path[0] = 0;
double totalSum = triangleValues[0, 0];
int columnPath = 0;

for (int i = 1; i <= triangleLines.Length - 1; i++)
{
    if (triangleUtilities[i, columnPath] > triangleUtilities[i, columnPath + 1])
    {
        totalSum = totalSum + triangleValues[i, columnPath];
    }
    else
    {
        totalSum = totalSum + triangleValues[i, columnPath + 1];
        columnPath++;
    }
}

Console.WriteLine("The maximum total from top to bottom of the triangle is:" + totalSum);