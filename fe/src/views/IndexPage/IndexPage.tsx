import { useUserData } from "../../components/UserContext/UserContext"
import { AdsListPage } from "../AdsListPage/AdsListPage"
import { OffersListPage } from "../OffersListPage/OffersListPage"

export const IndexPage = () => {
  const { data } = useUserData()

  if (data?.isSeller) {
    return <OffersListPage />
  }

  return <AdsListPage />
}
