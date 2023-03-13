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

        // destroy all but disabled object
        foreach (Transform item in checkoutItemsList.transform)
        {
            if (item.gameObject.name == "NewItem")
            {
                Destroy(item.gameObject);
            }
        }
        
        // add cart list
        foreach (KeyValuePair<int, string> item in cartList)
        {
            GameObject newItem = Instantiate(checkoutItemPrefab, checkoutItemPrefab.transform.parent);
            newItem.name = "NewItem";
            newItem.transform.Find("ProductName").GetComponent<TMP_Text>().text = item.Value;
            newItem.transform.Find("ProductPriceAmount").GetComponent<TMP_Text>().text = $"${OmazingPrices.price[item.Value]}";
            newItem.SetActive(true);
            print("newitem: " + newItem);
            
            // TODO fix duping issues for this part
            // fixed?
            GameObject newItemTy = Instantiate(orderReceivedItemPrefab, orderReceivedItemPrefab.transform.parent);
            newItemTy.name = "NewItem";
            newItemTy.transform.Find("ProductName").GetComponent<TMP_Text>().text = item.Value;
            newItemTy.transform.Find("ProductPriceAmount").GetComponent<TMP_Text>().text = $"${OmazingPrices.price[item.Value]}";
            newItemTy.SetActive(true);
            print("newitemty: " + newItemTy);
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
        
        // TODO: send to delivery manager
        // deliveryManager.NewDelivery(list);*/
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
