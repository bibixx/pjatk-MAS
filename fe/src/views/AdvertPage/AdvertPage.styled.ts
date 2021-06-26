import styled from "@emotion/styled";
import { Typography } from 'antd';

const { Title } = Typography;

export const Container = styled.div`
  max-width: 1024px;
  margin: 0 auto;
  padding: 2rem 0;
`;

export const Image = styled.img`
  aspect-ratio: 16 / 9;
  object-fit: cover;
  width: 100%;
`;

export const GameImage = styled.img`
  aspect-ratio: 1 / 1;
  object-fit: cover;
  width: 100%;
`;

export const GamesContainer = styled.div`
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  grid-gap: 2rem;
`;

export const NoMarginTitle = styled(Title)`
  margin-top: 0 !important;
  margin-bottom: 0 !important;
`;
