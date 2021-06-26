import { Tag } from "antd";
import { OffersResponse } from "./OffersListPage.types";

export const getDataSource = (response: OffersResponse) => [
  ...response.tradeOffers.map(({
    proposedGames,
    idOffer,
    advert,
    buyer,
    creationDate
  }) => ({
    idOffer,
    advertGames: advert.games.map(({ title }) => title),
    idAdvert: advert.idAdvert,
    proposedGames: proposedGames.map(({ title }) => title),
    buyer: buyer.userName,
    creationDate,
  })),
  ...response.buyoutOffers.map(({
    price,
    idOffer,
    advert,
    buyer,
    creationDate
  }) => ({
    idOffer,
    advertGames: advert.games.map(({ title }) => title),
    idAdvert: advert.idAdvert,
    price,
    buyer: buyer.userName,
    creationDate,
  }))
]

type Element = ReturnType<typeof getDataSource>[number]

export const columns = [
  {
    title: 'Id Ogłoszenia',
    dataIndex: 'idAdvert',
    key: 'idAdvert',
  },
  {
    title: 'Id Oferty',
    dataIndex: 'idOffer',
    key: 'idOffer',
  },
  {
    title: 'Data stworzenia',
    dataIndex: 'creationDate',
    key: 'creationDate',
    defaultSortOrder: 'descend',
    sorter: (a: Element, b: Element) => {
      return new Date(a.creationDate).getTime() - new Date(b.creationDate).getTime();
    },
  },
  {
    title: 'Gry',
    dataIndex: 'advertGames',
    key: 'advertGames',
    render: (games?: string[]) => (
      <>
        {games?.map(game => {
          return (
            <Tag color="green" key={game}>
              {game}
            </Tag>
          );
        })}
      </>
    ),
  },
  {
    title: 'Zaproponowane Gry',
    dataIndex: 'proposedGames',
    key: 'proposedGames',
    render: (games?: string[]) => (
      <>
        {games?.map(game => {
          return (
            <Tag color="geekblue" key={game}>
              {game}
            </Tag>
          );
        })}
      </>
    ),
  },
  {
    title: 'Cena',
    dataIndex: 'price',
    key: 'price',
  },
  {
    title: 'Kupujący',
    dataIndex: 'buyer',
    key: 'buyer',
  },
];
