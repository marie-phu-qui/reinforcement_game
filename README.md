# reinforcement_game

Pitch au 13.01.2020 : 

L'utilisateur a accès à un jeu customisé à sa propre expérience pour le 'fun'idéal (ni trop difficile ni trop facile). Dès le premier niveau, l'agent race track défini la difficulté à augmenter afin de rendre l'expérience d'utilisation la plus attractive

## Librairies :

[GYM](https://gym.openai.com/)


## Game Engine :

[Unity - avec le micro game karting en base](https://learn.unity.com/project/karting-template)

Version 2019.3.0f5

## ML Agent :

[Outil de reinforcement learning avec creation de Neural Network](https://github.com/Unity-Technologies/ml-agents)


### Train the neural network :
```mlagents-learn config.yaml --run-id=PlayerKart-2-0 --train``` (while on the config.yaml root)

### Visualise Tensorboard :
```tensorboard --logdir=summaries --port 6006``` (this will display on localhost:6006)
