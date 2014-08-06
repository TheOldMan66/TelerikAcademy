//ORIGINAL:
public void PrintStatistics(double[] arr, int count)
{
    double max, tmp;
    for (int i = 0; i < count; i++)
    {
        if (arr[i] > max)
        {
            max = arr[i];
        }
    }
    PrintMax(max);
    tmp = 0;
    max = 0;
    for (int i = 0; i < count; i++)
    {
        if (arr[i] < max)
        {
            max = arr[i];
        }
    }
    PrintMin(max);

    tmp = 0;
    for (int i = 0; i < count; i++)
    {
        tmp += arr[i];
    }
    PrintAvg(tmp/count);
}

//Refactored:

private void FindMax(double[] inputData, int count)
{
    double maxSoFar = inputData[0];
    for (int i = 1; i < count; i++)
    {
        if (inputData[i] > maxSoFar)
        {
            maxSoFar = inputData[i];
        }
    }
    return maxSoFar;
}

private void FindMin(double[] inputData, int count)
{
    double minSoFar = inputData[0];
    for (int i = 1; i < count; i++)
    {
        if (inputData[i] < minSoFar)
        {
            minSoFar = inputData[i];
        }
    }
    return minSoFar;
}

private void FindAverage(double[] inputData, int count)
{
	double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += inputData[i];
    }
    return sum / count;
}


public void PrintStatistics(double[] arr, int count)
{
	double maxValue = FindMax(arr, count);
    PrintMax(maxValue);
	double minValue = FindMax(arr, count);
    PrintMax(minSoFar);
	double avgValue = FindAverage(arr, count);
    PrintAvg(avgValue);    
}