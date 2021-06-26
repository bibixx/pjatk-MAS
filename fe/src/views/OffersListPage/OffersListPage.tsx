import { Table } from "antd";
import { Box } from "rebass";
import useSWR from "swr";
import { ErrorComponent } from "../../components/ErrorComponent/ErrorComponent";
import { LoadingPage } from "../../components/LoadingPage/LoadingPage";
import { fetcher } from "../../utils/fetcher";
import { OffersResponse } from "./OffersListPage.types";
import { columns, getDataSource } from "./OffersListPage.utils";
import { Typography } from 'antd';
const { Title } = Typography;

export const OffersListPage = () => {
  const { data, error } = useSWR<OffersResponse>('/api/offers', (url) => fetcher(url, {
    method: 'POST',
    body: JSON.stringify({
      "idSeller": 2
    }),
    headers: {
      "Content-Type": "application/json"
    }
  }))

  if (error) {
    return <ErrorComponent error={error} />
  }

  if (!data) {
    return <LoadingPage />
  }

  const tableData = getDataSource(data)

  return (
    <Box mt="2rem">
      <Title>Twoje oferty</Title>
      <Table columns={columns as any} dataSource={tableData as any} />
    </Box>
  );
}
