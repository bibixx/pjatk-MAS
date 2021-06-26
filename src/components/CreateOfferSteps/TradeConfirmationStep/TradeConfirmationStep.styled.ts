import styled from "@emotion/styled";

export const GameImage = styled.img`
  aspect-ratio: 1 / 1;
  object-fit: cover;
  width: 100%;
`;

export const GamesContainer = styled.div`
  display: grid;
  grid-template-columns: repeat(5, 1fr);
  grid-gap: 2rem;
`;
