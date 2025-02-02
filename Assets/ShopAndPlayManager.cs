using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Thirdweb;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopAndPlayManager : MonoBehaviour
{
    public string Address { get; private set; }

    string pandaDragonAddress = "0xfDb07FCf74F3bDDF7ceB71AC149b291261A21C42";
    string dragonAddress = "0xaC298F2839c48eA173f5A76434c83665ec5E1daf";
    string sharkAddress = "0x4a93870Ee7E1Af6366C7d50A06a6C3cD770DC531";
    string lionAddress = "0x35a4dD95020AE96419402Dd6465116bA86b86710";
    string parrotAddress = "0x4EadB0E9395845390832E6b44645eA99832ee4E1";
    string lizardAddress = "0x800915CF8dD71B329216C254A1Fa124b9cD81e57";
    string hippoAddress = "0xAFC41f020F3CA8D353AEd4D12b112ffc244D3d98";
    string monkeyAddress = "0xd368abB89F73F1f58b444adfC0B1b35Ce45d0D5F";
    string bullAddress = "0x0478338BbEBE1D6fb658C45B23E7742fA806fd09";
    string catTigerAddress = "0xe93D1FE8A43532690Cb5cdE48a4A34211b7C4227";
    string pandaParrotAddress = "0xe36215F85D7eDDAfCb8B3c2072928495e700FA6B";

    public Button pandaDragonButton;
    public Button dragonButton;
    public Button sharkButton;
    public Button lionButton;
    public Button parrotButton;
    public Button lizardButton;
    public Button hippoButton;
    public Button monkeyButton;
    public Button bullButton;
    public Button catTigerButton;
    public Button pandaParrotButton;

    public TMP_Text pandaDragonBalanceText;
    public TMP_Text dragonBalanceText;
    public TMP_Text sharkBalanceText;
    public TMP_Text lionBalanceText;
    public TMP_Text parrotBalanceText;
    public TMP_Text lizardBalanceText;
    public TMP_Text hippoBalanceText;
    public TMP_Text monkeyBalanceText;
    public TMP_Text bullBalanceText;
    public TMP_Text catTigerBalanceText;
    public TMP_Text pandaParrotBalanceText;

    public TextMeshProUGUI nftClaimingStatusText;

    public Button backButton;

    private void Start()
    {
        UpdateAllNFTBalance();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Loading");
    }

    private void HideAllButton()
    {
        pandaDragonButton.interactable = false;
        dragonButton.interactable = false;
        sharkButton.interactable = false;
        lionButton.interactable = false;
        parrotButton.interactable = false;
        lizardButton.interactable = false;
        hippoButton.interactable = false;
        monkeyButton.interactable = false;
        bullButton.interactable = false;
        catTigerButton.interactable = false;
        pandaParrotButton.interactable = false;
        backButton.interactable = false;
    }

    private void ShowAllButton()
    {
        pandaDragonButton.interactable = true;
        dragonButton.interactable = true;
        sharkButton.interactable = true;
        lionButton.interactable = true;
        parrotButton.interactable = true;
        lizardButton.interactable = true;
        hippoButton.interactable = true;
        monkeyButton.interactable = true;
        bullButton.interactable = true;
        catTigerButton.interactable = true;
        pandaParrotButton.interactable = true;
        backButton.interactable = true;
    }

    private void SetSingleTon(int indexValue)
    {
        if (indexValue == 1)
        {
            ResourceBoost.Instance.pandaDragon = 1;
        }
        else if (indexValue == 2)
        {
            ResourceBoost.Instance.dragon = 1;
        }
        else if (indexValue == 3)
        {
            ResourceBoost.Instance.shark = 1;

        }
        else if (indexValue == 4)
        {
            ResourceBoost.Instance.lion = 1;
        }
        else if (indexValue == 5)
        {
            ResourceBoost.Instance.parrot = 1;
        }
        else if (indexValue == 6)
        {
            ResourceBoost.Instance.lizard = 1;
        }
        else if (indexValue == 7)
        {
            ResourceBoost.Instance.hippo = 1;
        }
        else if (indexValue == 8)
        {
            ResourceBoost.Instance.monkey = 1;
        }
        else if (indexValue == 9)
        {
            ResourceBoost.Instance.bull = 1;
        }
        else if (indexValue == 10)
        {
            ResourceBoost.Instance.catTiger = 1;
        }
        else if (indexValue == 11)
        {
            ResourceBoost.Instance.pandaParrot = 1;
        }
    }

    private void UpdateBalanceText(int indexValue, string nftCount, int nftCountValue)
    {
        if (nftCountValue >= 1)
        {
            SetSingleTon(indexValue);
        }
        if (indexValue == 1)
        {
            pandaDragonBalanceText.text = nftCount;            
        }
        else if (indexValue == 2)
        {
            dragonBalanceText.text = nftCount;
        }
        else if (indexValue == 3)
        {
            sharkBalanceText.text = nftCount;
        }
        else if (indexValue == 4)
        {
            lionBalanceText.text = nftCount;
        }
        else if (indexValue == 5)
        {
            parrotBalanceText.text = nftCount;
        }
        else if (indexValue == 6)
        {
            lizardBalanceText.text = nftCount;
        }
        else if (indexValue == 7)
        {
            hippoBalanceText.text = nftCount;
        }
        else if (indexValue == 8)
        {
            monkeyBalanceText.text = nftCount;
        }
        else if (indexValue == 9)
        {
            bullBalanceText.text = nftCount;
        }
        else if (indexValue == 10)
        {
            catTigerBalanceText.text = nftCount;
        }
        else if (indexValue == 11)
        {
            pandaParrotBalanceText.text = nftCount;
        }
    }

    private async void UpdateNFTBalance(string NFTAddressSmartContract, int indexValue)
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        Debug.Log(Address);
        Contract contract = ThirdwebManager.Instance.SDK.GetContract(NFTAddressSmartContract);
        nftClaimingStatusText.text = "Updating NFT Balance...";
        nftClaimingStatusText.gameObject.SetActive(true);
        try
        {
            List<NFT> nftList = await contract.ERC721.GetOwned(Address);

            UpdateBalanceText(indexValue, nftList.Count.ToString(), nftList.Count);
            nftClaimingStatusText.text = "Updating Completed";

        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while fetching NFTs: {ex.Message}");
            // Handle the error, e.g., show an error message to the user or retry the operation
        }
    }

    public void UpdateAllNFTBalance()
    {
        UpdateNFTBalance(pandaDragonAddress, 1);
        UpdateNFTBalance(dragonAddress, 2);
        UpdateNFTBalance(sharkAddress, 3);
        UpdateNFTBalance(lionAddress, 4);
        UpdateNFTBalance(parrotAddress, 5);
        UpdateNFTBalance(lizardAddress, 6);
        UpdateNFTBalance(hippoAddress, 7);
        UpdateNFTBalance(monkeyAddress, 8);
        UpdateNFTBalance(bullAddress, 9);
        UpdateNFTBalance(catTigerAddress, 10);
        UpdateNFTBalance(pandaParrotAddress, 11);
    }

    public async void ClaimNFTPass(int indexValue)
    {
        string NFTAddressSmartContract = "";
        if (indexValue == 1)
        {
            NFTAddressSmartContract = pandaDragonAddress;
        }
        else if (indexValue == 2)
        {
            NFTAddressSmartContract = dragonAddress;
        }
        else if (indexValue == 3)
        {
            NFTAddressSmartContract = sharkAddress;
        }
        else if (indexValue == 4)
        {
            NFTAddressSmartContract = lionAddress;
        }
        else if (indexValue == 5)
        {
            NFTAddressSmartContract = parrotAddress;
        }
        else if (indexValue == 6)
        {
            NFTAddressSmartContract = lizardAddress;
        }
        else if (indexValue == 7)
        {
            NFTAddressSmartContract = hippoAddress;
        }
        else if (indexValue == 8)
        {
            NFTAddressSmartContract = monkeyAddress;
        }
        else if (indexValue == 9)
        {
            NFTAddressSmartContract = bullAddress;
        }
        else if (indexValue == 10)
        {
            NFTAddressSmartContract = catTigerAddress;
        }
        else if (indexValue == 11)
        {
            NFTAddressSmartContract = pandaParrotAddress;
        }
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        nftClaimingStatusText.text = "Claiming...";
        nftClaimingStatusText.gameObject.SetActive(true);
        HideAllButton();
        var contract = ThirdwebManager.Instance.SDK.GetContract(NFTAddressSmartContract);
        try
        {
            var result = await contract.ERC721.ClaimTo(Address, 1);
            nftClaimingStatusText.text = "Claimed NFT Pass!";
            ShowAllButton();
            SetSingleTon(indexValue);
            UpdateAllNFTBalance();
        }
        catch (Exception ex)
        {
            Debug.LogError($"An error occurred while claiming the NFT: {ex.Message}");
            // Optionally, update the UI to inform the user of the error
            nftClaimingStatusText.text = "Failed to claim NFT. Please try again.";
            ShowAllButton();
        }
    }

}
