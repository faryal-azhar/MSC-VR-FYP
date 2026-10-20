# Educational VR Game for Kids

A virtual reality game for Oculus Quest that helps kids (ages 5-8) learn colors, maths and spelling by playing.

MSc Computer Science final year project, University of Gujrat (2019-2021).
Full report: [MSc_Project_Report_Educational_VR_Game_for_Kids.pdf](MSc_Project_Report_Educational_VR_Game_for_Kids.pdf)

## Activities

- **Color Sorting** - Pick three colors, then sort the matching blocks into the buckets. Blocks say their color name out loud. Finishing the activity unlocks the door.
- **Basketball Maths** - Solve addition, subtraction, multiplication or division questions by throwing the ball into the basket with the right answer.
- **Spelling** - Use a laser gun to pop balloons in the right order and spell the scrambled word.

Each activity has easy, medium and hard levels, and high scores are saved between sessions.

## Built With

- Unity 2020.1 (Universal Render Pipeline)
- XR Interaction Toolkit with Oculus XR Plugin
- C#
- Oculus Quest

## Project Structure

```
Assets/Scripts
├── Core/           activity scheduler, music
├── Player/         movement, teleport, hands
├── HighScores/     saving and loading scores
├── Menu/           start screen
├── Activities/
│   ├── Basketball/
│   ├── Spelling/
│   └── ColorSorting/
└── Editor/         word list tools
```

## Getting Started

1. Open the project in Unity 2020.1.
2. Open `Assets/Scenes/1-Start.unity`.
3. Connect the Quest with Oculus Link and press Play, or build for Android to run it on the headset.
