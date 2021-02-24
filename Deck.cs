using System;

public class Deck
{

	public int cards[,] = new int[4, 13];

	for (int i = 0; i<5; i++)
			{
		for (int j = 0; j<14; j++)
			{
		cards[i][j]=j;
			}

			}
	public Deck()
	{

	
		
	}


}
