//***************************************************************************************
//** 983. Minimum Cost For Tickets                                            leetcode **
//***************************************************************************************

/*
int mincostTickets(int* days, int daysSize, int* costs, int costsSize) {
    int hash[400] = {0};
    int retNum = 0;
    int altretNum = 0;
    int single = 0;
    int seven = 0;
    int greedyseven[10] = {0};
    int thirty = 0;
    int greededSeven = 0;
    int sevenday = costs[1] / costs[0];
    int thirtyday = costs[2] / costs[1];
    int maxdiff = days[daysSize-1] - days[0];
//    printf("Maxdiff = %d\n",maxdiff);
    for(int x = 0; x < daysSize; x++)
    {
        hash[days[x]]++;
    }

    for(int y = days[0]; y < days[daysSize-1]+1; y++)
    {
        single = 0;
        seven = 0;
        thirty = 0;
        greededSeven = 0;
        for(int x = 0; x < 9; x++)
        {
            greedyseven[x] = 0;
        }
//        printf("day[%d] = %d\n",y,hash[y]);
        if(hash[y] == 1)
        {
            single = 1;
            for(int z = y; z < y+7; z++)
            {
                seven = seven + hash[z];
                greedyseven[1] = greedyseven[1] + hash[z+1];
                greedyseven[2] = greedyseven[2] + hash[z+2];
                greedyseven[3] = greedyseven[3] + hash[z+3];
                greedyseven[4] = greedyseven[4] + hash[z+4];
                greedyseven[5] = greedyseven[5] + hash[z+5];
                greedyseven[6] = greedyseven[6] + hash[z+6];
                greedyseven[7] = greedyseven[7] + hash[z+7];
            }
            for(int z = y; z < y+30; z++)
            {
                thirty = thirty + hash[z];
            }
            for(int x=0; x < sevenday; x++)
                {
                    if(greedyseven[x] > seven) seven = 0;
                    if(greededSeven < greedyseven[x]) greededSeven = greedyseven[x];
                }
            if(seven > sevenday)
            {
                if (thirty > thirtyday)
                {
                    printf("Took thirty day on day %d\n",y);
                    retNum = retNum + costs[2];
                    y = y + 29;
                }
                else if (seven > greededSeven)
                {
                    printf("Took seven day on day %d\n",y);
                    retNum = retNum + costs[1];
                    y = y + 6;
                }
            }
            else
            {
                printf("Took single day on day %d\n",y);
                retNum = retNum + costs[0];
            }
        }
    }


    for(int y = days[0]; y < days[daysSize-1]+1; y++)
    {
        single = 0;
        seven = 0;
        for(int x = 0; x < 9; x++)
        {
            greedyseven[x] = 0;
        }
//        printf("day[%d] = %d\n",y,hash[y]);
        if(hash[y] == 1)
        {
            single = 1;
            for(int z = y; z < y+7; z++)
            {
//                printf("Seven count day[%d] and hash[%d] = %d seven = %d\n",z,z,hash[z],seven);
                seven = seven + hash[z];
                greedyseven[1] = greedyseven[1] + hash[z+1];
                greedyseven[2] = greedyseven[2] + hash[z+2];
                greedyseven[3] = greedyseven[3] + hash[z+3];
                greedyseven[4] = greedyseven[4] + hash[z+4];
                greedyseven[5] = greedyseven[5] + hash[z+5];
                greedyseven[6] = greedyseven[6] + hash[z+6];
                greedyseven[7] = greedyseven[7] + hash[z+7];
            }

            for(int x=0; x < sevenday; x++)
                if(greedyseven[x] > seven) seven = 0;
            if(seven > sevenday)
            {
//                printf("Took seven day ticket day %d\n",y);
                altretNum = altretNum + costs[1];
                y = y + 6;
//                printf("day[%d] Now = %d\n",y,hash[y]);
            }
            else
            {
//                printf("Took single ticket day %d\n",y);
                altretNum = altretNum + costs[0];
            }
        }
//    printf("End day[%d] = %d\n",y,hash[y]);

    }
    
    if(altretNum > 0 && altretNum < retNum) return altretNum;
    else return retNum;
}
*/

int mincostTickets(int* days, int daysSize, int* costs, int costsSize)
{
    int dp[366] = {0};
    int travelDays[366] = {0}; 
    
    for (int i = 0; i < daysSize; i++)
    {
        travelDays[days[i]] = 1;
    }
    
    for (int i = 1; i <= 365; i++)
    {
        if (!travelDays[i]) 
        {
            dp[i] = dp[i - 1];
        }
        else 
        {
            int cost1 = dp[i - 1] + costs[0]; 
            int cost7 = dp[i >= 7 ? i - 7 : 0] + costs[1]; 
            int cost30 = dp[i >= 30 ? i - 30 : 0] + costs[2]; 
            dp[i] = fmin(fmin(cost1, cost7), cost30); 
        }
    }
    
    return dp[365];
}
