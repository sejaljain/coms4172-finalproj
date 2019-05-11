//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google Inc.">
// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleVR.HelloVR
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    /// <summary>Controls interactable teleporting objects in the Demo scene.</summary>
    [RequireComponent(typeof(Collider))]
    public class ObjectController : MonoBehaviour
    {
        /// <summary>
        /// The material to use when this object is inactive (not being gazed at).
        /// </summary>
        public Material gazedAtMaterial;

        /// <summary>The material to use when this object is active (gazed at).</summary>
        public Material inactiveMaterial;

        private Vector3 startingPosition;

        //private GameObject panel;

        private Renderer myRenderer;

        private string plantCals;
        private string plantName;
        private string ScoreNum;
        private int scoreTotal = 0;

        public string GetPlantCals(string plant)
        {
            string path = "Assets/plantDatabase.txt";
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                List<string> info = line.Split(',').ToList<string>();
                if (plant.Contains(info[0]))
                {
                    plantCals = info[1];
                }
            }
            return plantCals;
        }


        public string GetPlantName(string plant)
        {
            string path = "Assets/plantDatabase.txt";
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                List<string> info = line.Split(',').ToList<string>();
                if (plant.Contains(info[0]))
                {
                    plantName = info[0];
                }
            }
            return plantName;
        }

        public string GetScoreNum(string plant)
        {
            string path = "Assets/plantDatabase.txt";
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                List<string> info = line.Split(',').ToList<string>();
                if (plant.Contains(info[0]))
                {
                    ScoreNum = info[2];
                }
            }
            return ScoreNum;
        }



        /// <summary>Sets this instance's GazedAt state.</summary>
        /// <param name="gazedAt">
        /// Value `true` if this object is being gazed at, `false` otherwise.
        /// </param>
        public void SetGazedAt(bool gazedAt)
        {

            if (inactiveMaterial != null && gazedAtMaterial != null)
            {
                myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
                GameObject.Find("PlantInfo").GetComponent<Text>().text = gazedAt ? GetPlantCals(gameObject.name) : "";
                GameObject.Find("PlantName").GetComponent<Text>().text = gazedAt ? GetPlantName(gameObject.name) : "";
            }
        }

        /// <summary>Resets this instance and its siblings to their starting positions.</summary>
        public void Reset()
        {
            int sibIdx = transform.GetSiblingIndex();
            int numSibs = transform.parent.childCount;
            for (int i = 0; i < numSibs; i++)
            {
                GameObject sib = transform.parent.GetChild(i).gameObject;
                sib.transform.localPosition = startingPosition;
                sib.SetActive(i == sibIdx);
            }
        }

        /// <summary>Calls the Recenter event.</summary>
        public void Recenter()
        {
#if !UNITY_EDITOR
            GvrCardboardHelpers.Recenter();
#else
            if (GvrEditorEmulator.Instance != null)
            {
                GvrEditorEmulator.Instance.Recenter();
            }
#endif  // !UNITY_EDITOR
        }


        public void UpdateScore()
        {
            scoreTotal += Int32.Parse(GetScoreNum(gameObject.name));
            GameObject.Find("Score").GetComponent<Text>().text = String.Concat("Calories Captured: ", scoreTotal.ToString());
        }

        private void Start()
        {
            startingPosition = transform.localPosition;
            myRenderer = GetComponent<Renderer>();
            SetGazedAt(false);
        }
    }
}
