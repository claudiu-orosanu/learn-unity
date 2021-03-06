﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// core loop of this game
public enum GameState
{
    MainMenu,
    Playing,
    Win
}

public enum GameDifficulty
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}

public class Hacker : MonoBehaviour
{
    public GameState currentState;
    public GameDifficulty difficulty;
    public string password;

    private readonly string[] _easyPasswords = {"cat", "dog", "bird", "cool"};
    private readonly string[] _mediumPasswords = {"kitchen", "laptop", "window"};
    private readonly string[] _hardPasswords = {"astronaut", "restaurant", "intermediate", "perpetrator"};

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void ShowMainMenu()
    {
        currentState = GameState.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome! Are you ready?");
        Terminal.WriteLine("Press 1 for easy difficulty");
        Terminal.WriteLine("Press 2 for medium difficulty");
        Terminal.WriteLine("Press 3 for hard difficulty");
        Terminal.WriteLine("Type 'menu' to come back here");
    }

    private void OnUserInput(string input)
    {
        if (input == "menu")
        {
            // go to main menu if user wants to
            ShowMainMenu();
            return;
        }

        switch (currentState)
        {
            case GameState.MainMenu:

                if (ValidateUserInput(input))
                {
                    StartGame();
                }
                break;

            case GameState.Playing:
                CheckAnswer(input);
                break;
        }
    }

    private void CheckAnswer(string answer)
    {
        if (IsAnswerCorrect(answer))
        {
            ShowWinScreen();
        }
        else
        {
            Terminal.WriteLine("Wrong guess, try again!");
        }
    }

    private bool IsAnswerCorrect(string userAnswer)
    {
        return userAnswer == password;
    }

    private void ShowWinScreen()
    {
        currentState = GameState.Win;
        Terminal.WriteLine("You WON!!!");
    }

    private bool ValidateUserInput(string input)
    {
        var inputIsValid = Enum.TryParse(input, out GameDifficulty parsedDifficulty);
        if (!inputIsValid)
        {
            Terminal.WriteLine("You have to choose a difficulty level!");
            return false;
        }

        difficulty = parsedDifficulty;
        return true;
    }

    private void StartGame()
    {
        currentState = GameState.Playing;
        SetPassword();
        Terminal.ClearScreen();
        Terminal.WriteLine($"Guess the password! (Hint: {password.Anagram()})");
    }

    private void SetPassword()
    {
        switch (difficulty)
        {
            case GameDifficulty.Easy:
                password = _easyPasswords[Random.Range(0, _easyPasswords.Length)];
                break;
            case GameDifficulty.Medium:
                password = _mediumPasswords[Random.Range(0, _mediumPasswords.Length)];
                break;
            case GameDifficulty.Hard:
                password = _hardPasswords[Random.Range(0, _hardPasswords.Length)];
                break;
        }

    }
}