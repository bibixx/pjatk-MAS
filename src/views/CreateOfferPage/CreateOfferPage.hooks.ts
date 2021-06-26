import { useState } from "react"
import { useUserData } from "../../components/UserContext/UserContext"
import { fetcher } from "../../utils/fetcher"
import { PageStep } from "./CreateOfferPage.types"

export const useSteps = (advertId: number) => {
  const { data: userData } = useUserData()
  const [step, setStep] = useState<PageStep>(PageStep.PickOfferType)
  const [price, setPrice] = useState<number | undefined>()
  const [games, setGames] = useState<number[]>([])

  const onOfferPicked = (offerType: 'buy' | 'trade') => {
    setStep(offerType === 'buy' ? PageStep.InputBuyoutData : PageStep.InputTradeData)
  }

  const onBuyoutConfirm = (newPrice: number) => {
    setStep(PageStep.BuyoutConfirmation);
    setPrice(newPrice);
  }

  const onBuyoutCancel = () => {
    setStep(PageStep.InputBuyoutData)
  }

  const onTradeConfirm = (gamesPicked: number[]) => {
    setStep(PageStep.TradeConfirmation);
    setGames(gamesPicked);
  }

  const onTradeCancel = () => {
    setStep(PageStep.InputTradeData)
  }

  const createBuyoutOffer = async () => {
    try {
      setStep(PageStep.Loading);

      await fetcher(`/api/adverts/${advertId}/offers/buyout`, {
        method: 'POST',
        body: JSON.stringify({
          price,
          idBuyer: userData?.idUser
        }),
        headers: {
          "Content-Type": "application/json"
        }
      })

      setStep(PageStep.Success);
    } catch (error) {
      setStep(PageStep.Failure)
    }
  }

  const createTradeOffer = async () => {
    try {
      setStep(PageStep.Loading);

      await fetcher(`/api/adverts/${advertId}/offers/trade`, {
        method: 'POST',
        body: JSON.stringify({
          gameIds: games,
          idBuyer: userData?.idUser
        }),
        headers: {
          "Content-Type": "application/json"
        }
      })

      setStep(PageStep.Success);
    } catch (error) {
      setStep(PageStep.Failure)
    }
  }

  return {
    step,
    price,
    games,
    onOfferPicked,
    onBuyoutConfirm,
    createBuyoutOffer,
    onTradeConfirm,
    createTradeOffer,
    onBuyoutCancel,
    onTradeCancel,
  }
}
