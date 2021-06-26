import { useParams } from "react-router-dom";
import useSWR from "swr";

import { PickOfferTypeStep } from "../../components/CreateOfferSteps/PickOfferTypeStep/PickOfferTypeStep";
import { InputBuyoutDataStep } from "../../components/CreateOfferSteps/InputBuyoutDataStep/InputBuyoutDataStep";
import { BuyoutConfirmationStep } from "../../components/CreateOfferSteps/BuyoutConfirmationStep/BuyoutConfirmationStep";
import { SuccessStep } from "../../components/CreateOfferSteps/SuccessStep/SuccessStep";
import { InputTradeDataStep } from "../../components/CreateOfferSteps/InputTradeDataStep/InputTradeDataStep";
import { TradeConfirmationStep } from "../../components/CreateOfferSteps/TradeConfirmationStep/TradeConfirmationStep";
import { FailureStep } from "../../components/CreateOfferSteps/FailureStep/FailureStep";

import { ErrorComponent } from "../../components/ErrorComponent/ErrorComponent";
import { Advert } from "../../types/Advert";
import { useSteps } from "./CreateOfferPage.hooks";
import { PageStep } from "./CreateOfferPage.types";
import { Game } from "../../types/Game";
import { LoadingPage } from "../../components/LoadingPage/LoadingPage";

export const CreateOfferPage = () => {
  const { id } = useParams<{ id: string }>()
  const { data, error } = useSWR<Advert>(`/api/adverts/${id}`)
  const { data: availableGames, error: gamesError } = useSWR<Game[]>(`/api/games`)

  const {
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
  } = useSteps(+id)

  if (error || gamesError) {
    return <ErrorComponent error={error} />
  }

  if (!data || !availableGames) {
    return <LoadingPage />
  }

  const selectedGames = availableGames.filter(({ idGame }) => games.includes(idGame))

  const stepComponents: Record<PageStep, JSX.Element> = {
    [PageStep.PickOfferType]: <PickOfferTypeStep onOfferPicked={onOfferPicked} />,
    [PageStep.InputBuyoutData]: <InputBuyoutDataStep onConfirm={onBuyoutConfirm} />,
    [PageStep.BuyoutConfirmation]: <BuyoutConfirmationStep price={price as number} onConfirm={createBuyoutOffer} onCancel={onBuyoutCancel} />,
    [PageStep.InputTradeData]: <InputTradeDataStep onConfirm={onTradeConfirm} availableGames={availableGames} />,
    [PageStep.TradeConfirmation]: <TradeConfirmationStep selectedGames={selectedGames} onConfirm={createTradeOffer} onCancel={onTradeCancel} />,
    [PageStep.Loading]: <LoadingPage />,
    [PageStep.Success]: <SuccessStep />,
    [PageStep.Failure]: <FailureStep />,
  }

  return stepComponents[step];
}
