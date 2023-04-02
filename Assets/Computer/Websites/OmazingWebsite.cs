using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class OmazingWebsite : MonoBehaviour
{
    #region GameObjects
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

    [Header("Homepage")]
    [SerializeField] private TMP_Text cartPriceText;
    [SerializeField] private TMP_Text cartQuantityText;
    [SerializeField] private GameObject infoCard;
    [SerializeField] private GameObject infoCardName;
    [SerializeField] private GameObject infoCardPower;
    [SerializeField] private GameObject infoCardElectricity;
    [SerializeField] private GameObject infoCardCompatibility;

    [Header("Checkout")]
    [SerializeField] private TMP_Text checkoutSubtotalText;
    [SerializeField] private TMP_Text checkoutShippingText;
    [SerializeField] private TMP_Text checkoutDiscountText;
    [SerializeField] private TMP_Text checkoutTaxText;
    [SerializeField] private TMP_Text checkoutTotalText;
    [SerializeField] private GameObject checkoutItemsList;
    [SerializeField] private GameObject checkoutItemPrefab;
    [SerializeField] private GameObject noMoneyError;
    [SerializeField] private GameObject noCartItemsError;

    [Header("Order Received")]
    [SerializeField] private TMP_Text orderReceivedSubtotalText;
    [SerializeField] private TMP_Text orderReceivedShippingText;
    [SerializeField] private TMP_Text orderReceivedDiscountText;
    [SerializeField] private TMP_Text orderReceivedTaxText;
    [SerializeField] private TMP_Text orderReceivedTotalText;
    [SerializeField] private TMP_Text orderReceivedOrderIdText;
    [SerializeField] private TMP_Text orderReceivedCodeEnteredText;
    [SerializeField] private GameObject orderReceivedItemPrefab;

    [SerializeField] private SaladApp saladApp;
    #endregion

    #region Variables
    private float total;
    private float subtotal;
    private float shipping = 10.00f;
    private float discountAmount = 0;
    private string discountCode;

    private int orderId = 6969;

    private int cartItems = 0;

    private Dictionary<int, string> cartList = new Dictionary<int, string>();

    private List<GameObject> checkoutItems = new List<GameObject>();
    private List<GameObject> orderReceivedItems = new List<GameObject>();
    #endregion

    private void Start() 
    {
        StartCoroutine(IncreaseOrderID());
    }

    // Homepage
    public void AddToCart()
    {
        GameObject btn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        string item = btn.transform.parent.transform.parent.transform.name;

        cartItems++;
        Debug.Log("Added " + item + " to cart");
        cartList.Add(cartItems, item);
        UpdateCartQuantity();
        UpdateCartPrice(Hardware.price[item]);

        Debug.Log("Cart List: ");
        foreach (KeyValuePair<int, string> entry in cartList)
        {
            Debug.Log("Key: " + entry.Key + " Value: " + entry.Value);
        }
    }

    private void UpdateCartQuantity()
    {
        int quantity = int.Parse(cartQuantityText.text);
        quantity++;
        cartQuantityText.text = quantity.ToString();
    }

    private void UpdateCartPrice(float price)
    {
        float currentPrice = float.Parse(cartPriceText.text.Replace("$", ""));
        currentPrice += price;
        subtotal += price;
        cartPriceText.text = "$" + currentPrice;
    }
    
    public void ChangePage(string newPage) 
    {
        Type myType = GetType();
        FieldInfo[] fields = myType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields)
        {
            if (field.FieldType == typeof(GameObject)) {
                GameObject newObject = (GameObject) field.GetValue(this);
                newObject.SetActive(false);
            }
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
                GoToCheckout();
                break;
            case "order":
                checkout.SetActive(false);
                orderReceived.SetActive(true);
                break;
            
        }
    }

    public void ShowInfo() 
    {
        GameObject btn = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        string itemName = btn.transform.parent.transform.parent.Find("Name").GetComponent<TMP_Text>().text;
        string type = btn.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.name;

        infoCardName.SetActive(true);
        infoCardPower.SetActive(true);
        infoCardElectricity.SetActive(true);
        infoCardCompatibility.SetActive(true);

        infoCardName.GetComponent<TMP_Text>().text = itemName;
        switch (type) {
            case "CPU":
                infoCardPower.GetComponent<TMP_Text>().text = "Power: " + Hardware.cpu[itemName][0];
                infoCardElectricity.GetComponent<TMP_Text>().text = "Electricity: " + Hardware.cpu[itemName][1] + "w";
                string compatibilityString = string.Join(", ", HardwareCompatibility.cpu[itemName]);
                infoCardCompatibility.GetComponent<TMP_Text>().text = compatibilityString;
                break;
            case "GPU":
                infoCardPower.GetComponent<TMP_Text>().text = "Power: " + Hardware.gpu[itemName][0];
                infoCardElectricity.GetComponent<TMP_Text>().text = "Electricity: " + Hardware.gpu[itemName][1] + "w";
                break;
        }
        infoCard.SetActive(true);
    }

    public void CloseInfo()
    {
        infoCardName.GetComponent<TMP_Text>().text = "Placeholder";
        infoCardPower.GetComponent<TMP_Text>().text = "N/A";
        infoCardElectricity.GetComponent<TMP_Text>().text = "0w";
        infoCardCompatibility.GetComponent<TMP_Text>().text = "N/A";
        infoCard.SetActive(false);
    }

    // Checkout
    public void GoToCheckout()
    {
        categories.SetActive(false);
        checkout.SetActive(true);
        checkoutItemsList.SetActive(true);

        // clear list
        if (checkoutItems.Count > 0)
        {
            foreach (GameObject item in checkoutItems)
            {
                Destroy(item);
            }
        }

        if (orderReceivedItems.Count > 0)
        {
            foreach (GameObject item in orderReceivedItems)
            {
                Destroy(item);
            }
        }
        
        // add to cart list
        foreach (KeyValuePair<int, string> item in cartList)
        {
            GameObject newItem = Instantiate(checkoutItemPrefab, checkoutItemPrefab.transform.parent);
            newItem.name = "NewItem";
            newItem.transform.Find("ProductName").GetComponent<TMP_Text>().text = item.Value;
            newItem.transform.Find("ProductPriceAmount").GetComponent<TMP_Text>().text = $"${Hardware.price[item.Value]}";
            newItem.SetActive(true);
            checkoutItems.Add(newItem);
            
            // fixed?
            GameObject newItemTy = Instantiate(orderReceivedItemPrefab, orderReceivedItemPrefab.transform.parent);
            newItemTy.name = "NewItem";
            newItemTy.transform.Find("ProductName").GetComponent<TMP_Text>().text = item.Value;
            newItemTy.transform.Find("ProductPriceAmount").GetComponent<TMP_Text>().text = $"${Hardware.price[item.Value]}";
            newItemTy.SetActive(true);
            orderReceivedItems.Add(newItemTy);
        }
        
        float subtotal = this.subtotal;
        
        checkoutSubtotalText.text = subtotal.ToString();
        UpdateCheckout();
    }
    
    private void UpdateCheckout()
    {
        float subtotal = this.subtotal;
        total = subtotal + shipping - discountAmount;

        checkoutSubtotalText.text = $"${subtotal}";
        checkoutShippingText.text = $"${shipping}";
        checkoutDiscountText.text = $"-${discountAmount}";
        checkoutTotalText.text = $"${total}";

        UpdateOrderReceived(subtotal, shipping, subtotal + shipping - discountAmount);
    }

    public void PlaceOrder()
    {
        float total = float.Parse(checkoutTotalText.text.Replace("$", ""));
        if (cartItems == 0)
        {
            noCartItemsError.SetActive(true);
            return;
        }
        if (GameManager.instance.Money < total)
        {
            noMoneyError.SetActive(true);
            return;
        }
        GameManager.instance.Money -= total;

        UpdateCheckout();
        
        orderReceivedOrderIdText.text = $"#{orderId.ToString()}";

        /*List<String> list = new List<String>();
        
        foreach (KeyValuePair<int, string> entry in cartList)
        {
            list.Add(entry.Value);
        }
        
        // TODO: create and send to delivery manager
        // deliveryManager.NewDelivery(list);*/

        // Set current CPU
        foreach (KeyValuePair<string, float[]> cpu in Hardware.cpu) {
            if (cartList.ContainsValue(cpu.Key)) {
                GameManager.instance.CurrentCPU = cpu.Key;
                Debug.Log("Current CPU: " + GameManager.instance.CurrentCPU);
                GameManager.instance.hardwarePower += Hardware.cpu[GameManager.instance.CurrentCPU][0];
                Debug.Log("Current hardware power: " + GameManager.instance.hardwarePower);
                break;
            }
        }
        saladApp.AddToPerformance(GameManager.instance.CurrentCPU, "CPU");

        // Set current RAM(s)
        foreach (KeyValuePair<string, float[]> hardware in Hardware.ram) {
            foreach (KeyValuePair<int, string> cartItem in cartList) {
                if (hardware.Key == cartItem.Value) {
                    Debug.Log("Added " + hardware.Key + " to RAM list");
                    GameManager.instance.CurrentRAMs.Add(hardware.Key);
                    Debug.Log("Current RAMs: " + GameManager.instance.CurrentRAMs);
                }
            }
        }

        // Set current GPU(s)
        foreach (KeyValuePair<string, float[]> hardware in Hardware.gpu) {
            foreach (KeyValuePair<int, string> cartItem in cartList) {
                if (hardware.Key == cartItem.Value) {
                    Debug.Log("Added " + hardware.Key + " to GPU list");
                    GameManager.instance.CurrentGPUs.Add(hardware.Key);
                    Debug.Log("Current GPUs: " + GameManager.instance.CurrentGPUs);
                    GameManager.instance.hardwarePower += Hardware.gpu[GameManager.instance.CurrentGPUs[0]][0];
                    Debug.Log("Current hardware power: " + GameManager.instance.hardwarePower);
                    saladApp.AddToPerformance(hardware.Key, "GPU");
                }
            }
        }

        // Set current motherboard
        foreach (KeyValuePair<string, float[]> hardware in Hardware.mobo) {
            if (cartList.ContainsValue(hardware.Key)) {
                GameManager.instance.CurrentMobo = hardware.Key;
                Debug.Log("Current mobo: " + GameManager.instance.CurrentMobo);
                break;
            }
        }

        // Set current PSU
        foreach (KeyValuePair<string, float[]> hardware in Hardware.psu) {
            if (cartList.ContainsValue(hardware.Key)) {
                GameManager.instance.CurrentPSU = hardware.Key;
                Debug.Log("Current PSU: " + GameManager.instance.CurrentPSU);
                break;
            }
        }
        
        // Set current storage(s)
        foreach (KeyValuePair<string, float[]> hardware in Hardware.storage) {
            foreach (KeyValuePair<int, string> cartItem in cartList) {
                if (hardware.Key == cartItem.Value) {
                    Debug.Log("Added " + hardware.Key + " to storage list");
                    GameManager.instance.CurrentStorages.Add(hardware.Key);
                    Debug.Log("Current storages: " + GameManager.instance.CurrentStorages);
                }
            }
        }

        // Set current cooling(s)
        foreach (KeyValuePair<string, float[]> hardware in Hardware.cooling) {
            foreach (KeyValuePair<int, string> cartItem in cartList) {
                if (hardware.Key == cartItem.Value) {
                    Debug.Log("Added " + hardware.Key + " to cooling list");
                    GameManager.instance.CurrentCoolings.Add(hardware.Key);
                    Debug.Log("Current coolings: " + GameManager.instance.CurrentCoolings);
                }
            }
        }

        // Set current case
        foreach (KeyValuePair<string, float[]> hardware in Hardware.pcCase) {
            if (cartList.ContainsValue(hardware.Key)) {
                GameManager.instance.CurrentCase = hardware.Key;
                Debug.Log("Current case: " + GameManager.instance.CurrentCase);
                break;
            }
        }

        // Clear cart
        cartList.Clear();
        cartItems = 0;
        cartQuantityText.text = "0";
        cartPriceText.text = "$0.00";
        checkoutSubtotalText.text = "$0.00";
        subtotal = 0;

        foreach (GameObject item in checkoutItems)
        {
            Destroy(item);
        }

        checkout.SetActive(false);
        orderReceived.SetActive(true);
    }

    public void ApplyDiscount(string code)
    {
        discountCode = code;
        if (Hardware.code.ContainsKey(code))
        {
            float discountPercent = Hardware.code[code];
            float discountAmount = (subtotal + float.Parse(checkoutShippingText.text.Replace("$", ""))) * discountPercent / 100f;
            this.discountAmount = discountAmount;
            UpdateCheckout();
        }
        else
        {
            discountCode = null;
            discountAmount = 0;
            UpdateCheckout();
        }
    }

    public void ClearCart()
    {
        cartList.Clear();
        cartItems = 0;

        subtotal = 0;
        discountAmount = 0;

        cartQuantityText.text = "0";
        cartPriceText.text = "$0.00";

        UpdateCheckout();

        foreach (GameObject item in checkoutItems)
        {
            Destroy(item);
        }
    }

    // Order received
    private void UpdateOrderReceived(float subtotal, float shipping, float total)
    {
        orderReceivedSubtotalText.text = $" ${subtotal}";
        orderReceivedShippingText.text = $" ${shipping}";
        orderReceivedDiscountText.text = checkoutDiscountText.text;
        if (discountCode != null) orderReceivedCodeEnteredText.text = discountCode;
        orderReceivedTotalText.text = $"${total}";
    }

    IEnumerator IncreaseOrderID()
    {
        while (true) 
        {
            orderId += UnityEngine.Random.Range(0, 100);
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 5));
        }
    }
    
}
