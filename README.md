# GainPlay - Multiplayer network

Ik heb mijn terrain destruction game omgebouwd naar een multiplayer FPS game.
De spelers kunnen elkaar zien bewegen, zien shieten, dingen instantiaten 
en pepaalde objecten in de server laten bewegen (knockback).

## Features

- [Exploding Nade](https://github.com/Yaruno292/networkFps/blob/master/Scripts/Object/NadeExplode.cs)
- [Player Shoot](https://github.com/Yaruno292/networkFps/blob/master/Scripts/Player/PlayerShoot.cs)
  Werkt nog niet 100% op het netwerk, maar ik heb er wel veel tijd ingestoken.
- [Simple Networked Target](https://github.com/Yaruno292/networkFps/blob/master/Scripts/Object/Target.cs)

- Er is ook veel aangepast aan de prefabs en objecten.

## Software Anaylse 
Ik heb unity gekozen omdat ik daar al een bestaande game in had
en waarvan ik het multiplayer wilde maken.
Unity heeft ook al ingebouwde network objecten en ik wilde daar graag meer over leren.

## Leerdoelen 
- Andere spelers zien bewegen.
- Spelers die de omgeving veranderen in de server wereld.
- Granaten naar elkaar gooien.
- Elkaar schieten.

## Planning

### Week 1:
- ma: Onderzoek naar hoe networking werkt in Unity
- di: volgen van tutorial
- wo: zelf dingen testen
- do: Network player movement
- vri: Network instantiated objects

### week 2:
- ma: Network knockback
- di: Network HP
- wo: Proberen al bestaande objecten in de wereld te syncen, maar t werkt niet..
    nog steeds niet.. alleen als de objecten in de 2e state komen(instantiated ver).

## Bronnen

- [De youtube tutorial](https://www.youtube.com/watch?v=V6wEvT6G92M)
