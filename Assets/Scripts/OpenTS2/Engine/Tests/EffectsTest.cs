﻿using OpenTS2.Content;
using OpenTS2.Files;
using OpenTS2.Scenes;
using UnityEngine;


[RequireComponent(typeof(EffectsManager))]
public class EffectsTest : MonoBehaviour
{
    private void Start()
    {
        var contentProvider = ContentProvider.Get();

        // Load base game assets.
        contentProvider.AddPackages(
            Filesystem.GetPackagesInDirectory(Filesystem.GetDataPathForProduct(ProductFlags.BaseGame) + "/Res/Sims3D"));

        var effectsManager = GetComponent<EffectsManager>();
        effectsManager.StartEffect("neighborhood_house_smoking");
    }
}