using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
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

    [Header("Homepage")]
    [SerializeField] private TMP_Text cartPriceText;
    [SerializeField] private TMP_Text cartQuantityText;

    [Header("Checkout")]
    [SerializeField] private TMP_Text checkoutSubtotalText;
    [SerializeField] private TMP_Text checkoutShippingText;
    [SerializeField] private TMP_Text checkoutDiscountText;
    [SerializeField] private TMP_Text checkoutTaxText;
    [SerializeField] private TMP_Text checkoutTotalText;
    [SerializeField] private GameObject checkoutItemsList;
    [SerializeField] private GameObject checkoutItemPrefab;

    [Header("Order Received")]
    [SerializeField] private TMP_Text orderReceivedSubtotalText;
    [SerializeField] private TMP_Text orderReceivedShippingText;
    [SerializeField] private TMP_Text orderReceivedDiscountText;
    [SerializeField] private TMP_Text orderReceivedTaxText;
    [SerializeField] private TMP_Text orderReceivedTotalText;
    [SerializeField] private TMP_Text orderReceivedOrderIdText;
    [SerializeField] private GameObject orderReceivedItemPrefab;

    private float subtotal;
    private string discountCode;

    private int orderId = 6969;

    private int cartItems = 0;

    private Dictionary<int, string> cartList = new Dictionary<int, string>();

    private List<GameObject> checkoutItems = new List<GameObject>();
    private List<GameObject> orderReceivedItems = new List<GameObject>();

    private void Start() 
    {
        StartCoroutine(IncreaseOrderID());
    }

    // Homepage
    public void AddToCart(string item)
    {
        cartItems++;
        Debug.Log("Added " + item + " to cart");
        cartList.Add(cartItems, item);
        UpdateCartQuantity();
        UpdateCartPrice(OmazingPrices.price[item]);

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
            newItem.transform.Find("ProductPriceAmount").GetComponent<TMP_Text>().text = $"${OmazingPrices.price[item.Value]}";
            newItem.SetActive(true);
            checkoutItems.Add(newItem);
            
            // fixed?
            GameObject newItemTy = Instantiate(orderReceivedItemPrefab, orderReceivedItemPrefab.transform.parent);
            newItemTy.name = "NewItem";
            newItemTy.transform.Find("ProductName").GetComponent<TMP_Text>().text = item.Value;
            newItemTy.transform.Find("ProductPriceAmount").GetComponent<TMP_Text>().text = $"${OmazingPrices.price[item.Value]}";
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
        float shipping = float.Parse(checkoutShippingText.text.Replace("$", ""));

        checkoutSubtotalText.text = $"${subtotal}";
        checkoutShippingText.text = $"${shipping}";
        checkoutTotalText.text = $"${subtotal + shipping}";
        
        // update after adding
        subtotal = this.subtotal;
        shipping = float.Parse(checkoutShippingText.text.Replace("$", ""));

        UpdateOrderReceived(this.subtotal, shipping, subtotal + shipping);
    }

    public void PlaceOrder()
    {
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

        // Set current GPU(s)
        foreach (KeyValuePair<string, float[]> hardwareGPUs in Hardware.gpu) {
            foreach (KeyValuePair<int, string> cartGPUs in cartList) {
                if (hardwareGPUs.Key == cartGPUs.Value) {
                    Debug.Log("Added " + hardwareGPUs.Key + " to GPU list");
                    GameManager.instance.CurrentGPUs.Add(hardwareGPUs.Key);
                    Debug.Log("Current GPUs: " + GameManager.instance.CurrentGPUs);
                    GameManager.instance.hardwarePower += Hardware.gpu[GameManager.instance.CurrentGPUs[0]][0];
                    Debug.Log("Current hardware power: " + GameManager.instance.hardwarePower);
                }
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

    // Order received
    private void UpdateOrderReceived(float subtotal, float shipping, float total)
    {
        orderReceivedSubtotalText.text = $" ${subtotal}";
        orderReceivedShippingText.text = $" ${shipping}";
        orderReceivedDiscountText.text = checkoutDiscountText.text;
        if (discountCode != null) checkoutDiscountText.text = discountCode;
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
