using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class OmazingWebsite : MonoBehaviour
{
    [SerializeField] private GameObject cpu;
    [SerializeField] private GameObject ram;
    [SerializeField] private GameObject gpu;
    [SerializeField] private GameObject mobo;
    [SerializeField] private GameObject psu;
    [SerializeField] private GameObject storage;
    [SerializeField] private GameObject fans;
    [SerializeField] private GameObject pcCase;
    [SerializeField] private GameObject software;
    [SerializeField] private GameObject accessories;

    [Header("Pages")]
    [SerializeField] private GameObject categories;
    [SerializeField] private GameObject checkout;
    [SerializeField] private GameObject orderReceived;

    public void Start()
    {
        
    }

    public void ChangePage(string newPage) 
    {
        Type myType = GetType();
        FieldInfo[] fields = myType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields)
        {
            GameObject newObject = (GameObject) field.GetValue(this);
            newObject.SetActive(false);
        }

        switch (newPage)
        {
            case "cpu":
                categories.SetActive(true);
                cpu.SetActive(true);
                break;
            case "ram":
                categories.SetActive(true);
                ram.SetActive(true);
                break;
            case "gpu":
                categories.SetActive(true);
                gpu.SetActive(true);
                break;
            case "mobo":
                categories.SetActive(true);
                mobo.SetActive(true);
                break;
            case "psu":
                categories.SetActive(true);
                psu.SetActive(true);
                break;
            case "storage":
                categories.SetActive(true);
                storage.SetActive(true);
                break;
            case "fans":
                categories.SetActive(true);
                fans.SetActive(true);
                break;
            case "case":
                categories.SetActive(true);
                pcCase.SetActive(true);
                break;
            case "software":
                categories.SetActive(true);
                software.SetActive(true);
                break;
            case "accessories":
                categories.SetActive(true);
                accessories.SetActive(true);
                break;
            case "checkout":
                categories.SetActive(false);
                checkout.SetActive(true);
                break;
            case "order":
                checkout.SetActive(false);
                orderReceived.SetActive(true);
                break;
            
        }
    }
    
}
