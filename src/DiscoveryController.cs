
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
//using System.Data;
using System.Diagnostics;
using SwinGameSDK;

/// <summary>
/// The battle phase is handled by the DiscoveryController.
/// </summary>
static class DiscoveryController
{

	/// <summary>
	/// Handles input during the discovery phase of the game.
	/// </summary>
	/// <remarks>
	/// Escape opens the game menu. Clicking the mouse will
	/// attack a location.
	/// </remarks>
	public static void HandleDiscoveryInput()
	{
		if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE)) {
//			AddNewState(GameState.ViewingGameMenu);
			GameController.AddNewState(GameState.ViewingGameMenu);
		}

		if (SwinGame.MouseClicked(MouseButton.LeftButton)) {
			DoAttack();
		}
	}

	/// <summary>
	/// Attack the location that the mouse if over.
	/// </summary>
	private static void DoAttack()
	{
		Point2D mouse = default(Point2D);

		mouse = SwinGame.MousePosition();

		//Calculate the row/col clicked
		int row = 0;
		int col = 0;
//		row = Convert.ToInt32(Math.Floor((mouse.Y - FIELD_TOP) / (CELL_HEIGHT + CELL_GAP)));
		row = Convert.ToInt32(Math.Floor((mouse.Y - UtilityFunctions.FIELD_TOP) / (UtilityFunctions.CELL_HEIGHT + UtilityFunctions.CELL_GAP)));
//		col = Convert.ToInt32(Math.Floor((mouse.X - FIELD_LEFT) / (CELL_WIDTH + CELL_GAP)));
		col = Convert.ToInt32(Math.Floor((mouse.X - UtilityFunctions.FIELD_LEFT) / (UtilityFunctions.CELL_WIDTH + UtilityFunctions.CELL_GAP)));

//		if (row >= 0 & row < HumanPlayer.EnemyGrid.Height) {
		if (row >= 0 & row < GameController.HumanPlayer.EnemyGrid.Height) {
//			if (col >= 0 & col < HumanPlayer.EnemyGrid.Width) {
			if (col >= 0 & col < GameController.HumanPlayer.EnemyGrid.Width) {
//				Attack(row, col);
				GameController.Attack(row, col);
			}
		}
	}

	/// <summary>
	/// Draws the game during the attack phase.
	/// </summary>s
	public static void DrawDiscovery()
	{
		const int SCORES_LEFT = 172;
		const int SHOTS_TOP = 157;
		const int HITS_TOP = 206;
		const int SPLASH_TOP = 256;

		if ((SwinGame.KeyDown(KeyCode.vk_LSHIFT) | SwinGame.KeyDown(KeyCode.vk_RSHIFT)) & SwinGame.KeyDown(KeyCode.vk_c)) {
//			DrawField(HumanPlayer.EnemyGrid, ComputerPlayer, true);
			UtilityFunctions.DrawField(GameController.HumanPlayer.EnemyGrid, GameController.ComputerPlayer, true);
		} else {
//			DrawField(HumanPlayer.EnemyGrid, ComputerPlayer, false);
			UtilityFunctions.DrawField(GameController.HumanPlayer.EnemyGrid, GameController.ComputerPlayer, false);
		}

//		DrawSmallField(HumanPlayer.PlayerGrid, HumanPlayer);
		UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);
//		DrawMessage();
		UtilityFunctions.DrawMessage();

//		SwinGame.DrawText(HumanPlayer.Shots.ToString(), Color.White, GameFont("Menu"), SCORES_LEFT, SHOTS_TOP);
		SwinGame.DrawText(GameController.HumanPlayer.Shots.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SHOTS_TOP);
//		SwinGame.DrawText(HumanPlayer.Hits.ToString(), Color.White, GameFont("Menu"), SCORES_LEFT, HITS_TOP);
		SwinGame.DrawText(GameController.HumanPlayer.Hits.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, HITS_TOP);
//		SwinGame.DrawText(HumanPlayer.Missed.ToString(), Color.White, GameFont("Menu"), SCORES_LEFT, SPLASH_TOP);
		SwinGame.DrawText(GameController.HumanPlayer.Missed.ToString(), Color.White, GameResources.GameFont("Menu"), SCORES_LEFT, SPLASH_TOP);
	}

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
