# Entraîner sur Azure Linux VM

Suivre les instructions  de cette page [web](https://github.com/Unity-Technologies/ml-agents/blob/latest_release/docs/Training-on-Microsoft-Azure.md).

## Remarques

1. La VM utilisée c'est celle qui est déjà pre-configuré (celle de data scientist).
2. J'ai choisi la connexion ssh. Il faut suivre ce 
[tuto](https://docs.microsoft.com/fr-fr/azure/virtual-machines/linux/quick-create-portal).
La création de la clé peut se faire avec le shell Azure mais c'est mieux de le faire depuis le terminal (macOS) 
pour générer la clé depuis notre ordi. Ainsi on peut se connecter et transférer directement nos dossier/fichiers 
au serveur.
3. Dans la partie où il faut créer l'executable de Linux, il faut cocher Server Build qui devrait avoir la même
fonction que headless mode. Attention à envoyer tous les fichiers crées et pas seulement l'executable.
4. Il faut mettre le dossier du jeu dans le sous-dossier ml-agents que tu as transféré à la VM.
5. Quand tu executes cette commande
```sh
mlagents-learn <trainer_config> --env=<your_app> --run-id=<run_id> --train
```
le fichier trainer_config est celui que tu utilise pour entraîner ce jeu. 
Il doit être déplacé de ton ordi vers la VM dans le dossier ml-agents.


